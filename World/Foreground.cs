using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ArrPeeGee.World
{
    internal static class Foreground
    {
        public static List<Tile> tiles = new List<Tile>
        {
            new Tile("stone", true, 1.0),
        };

        public static void Render(SpriteBatch _spriteBatch, Map map, int mapWidth)
        {
           
        }
    }
}
