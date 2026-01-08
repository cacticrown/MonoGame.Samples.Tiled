This repo contains a tiled project as well as a tool that generates levels for the [monogame 2d platformer example](https://github.com/MonoGame/MonoGame.Samples). The game uses simple txt files as levels, that are very annoying to edit by hand, which is the reason why I made this tool.

## Usage
Simply put all your tiled maps as well as the built binaries of the tool into a folder. Then run the tool and it will put all the generated files into the `output` folder. Now you can replace the old level files with the newly generated ones.

> [!IMPORTANT]  
> Make sure to save your tiled maps as tmj and not tmx. Otherwise the tool will skip them.

I already put the tool as an exe into the folder with the tiled maps, but if you need it for other platforms, you will need to build it yourself.

Also make sure to use this [tileset](tilemap-editor/tileset.tsx)
