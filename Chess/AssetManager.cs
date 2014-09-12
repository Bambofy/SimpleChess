using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Chess
{
    static class AssetManager
    {
        // Dunno how else to hold all the assets.
        public static Dictionary<Colours, Dictionary<Types, Texture>> Sprites;

        public static void LoadSprites()
        {
            Console.WriteLine("Loading textures...");

            // Load assets... (needs perf opti i'm sure)
            Sprites = new Dictionary<Colours, Dictionary<Types, Texture>>();
            Sprites[Colours.Black] = new Dictionary<Types, Texture>();
            Sprites[Colours.Black][Types.Pawn] = new Texture("Assets/1_pawn.png");
            Sprites[Colours.Black][Types.Rook] = new Texture("Assets/1_rook.png");
            Sprites[Colours.Black][Types.Knight] = new Texture("Assets/1_knight.png");
            Sprites[Colours.Black][Types.Bishop] = new Texture("Assets/1_bishop.png");
            Sprites[Colours.Black][Types.Queen] =new Texture("Assets/1_queen.png");
            Sprites[Colours.Black][Types.King] = new Texture("Assets/1_king.png");

            Sprites[Colours.White] = new Dictionary<Types, Texture>();
            Sprites[Colours.White][Types.Pawn] = new Texture("Assets/0_pawn.png");
            Sprites[Colours.White][Types.Rook] = new Texture("Assets/0_rook.png");
            Sprites[Colours.White][Types.Knight] = new Texture("Assets/0_knight.png");
            Sprites[Colours.White][Types.Bishop] = new Texture("Assets/0_bishop.png");
            Sprites[Colours.White][Types.Queen] = new Texture("Assets/0_queen.png");
            Sprites[Colours.White][Types.King] = new Texture("Assets/0_king.png");

            // Empty space
            Sprites[Colours.Empty] = new Dictionary<Types, Texture>();
            Sprites[Colours.Empty][Types.Empty] = null;

            Console.WriteLine("Loaded Sprites!");
        }

        public static Texture GetSprite(Types type, Colours colour)
        {
            if (!Sprites.ContainsKey(colour)) return null;
            return Sprites[colour].ContainsKey(type) ? Sprites[colour][type] : null;
        }
    }
}
