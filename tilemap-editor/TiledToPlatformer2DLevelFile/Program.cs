using System;
using System.IO;
using System.Text;
using System.Text.Json;

class TiledToTxt
{
    static void Main(string[] args)
    {
        foreach(var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.tmj"))
        {
            string outputFile = Path.ChangeExtension(file, ".txt");
            outputFile = Path.Combine(Directory.CreateDirectory("output").FullName, Path.GetFileName(outputFile));

            string json = File.ReadAllText(file);
            using JsonDocument doc = JsonDocument.Parse(json);

            JsonElement root = doc.RootElement;

            int width = root.GetProperty("width").GetInt32();
            int height = root.GetProperty("height").GetInt32();

            JsonElement layer = root.GetProperty("layers")[0];
            JsonElement data = layer.GetProperty("data");

            if (data.GetArrayLength() != width * height)
                throw new Exception("Tile data size does not match width * height");

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;
                    int tileId = data[index].GetInt32();

                    char symbol = TileToChar(tileId);
                    sb.Append(symbol);
                }
                sb.AppendLine();
            }

            File.WriteAllText(outputFile, sb.ToString());
            Console.WriteLine("Conversion complete.");
        }
    }

    static char TileToChar(int tileId)
    {
        // Strategic control point: define your level language here
        switch (tileId)
        {
            case 0: return '.';   // empty
            case 1: return 'X';
            case 2: return '1';
            case 3: return '2';
            case 4: return 'A';
            case 5: return 'B';
            case 7: return 'P';
            case 8: return '3';
            case 9: return '4';
            case 10: return 'C';
            case 11: return 'D';
            case 13: return '#';
            case 14: return ';';
            case 15: return '-';
            case 19: return ':';
            default: return '?';  // unknown / invalid tile
        }
    }
}
