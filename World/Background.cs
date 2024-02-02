using System.Collections.Generic;

namespace ArrPeeGee.World
{
    internal static class Background
    {
        public static List<Tile> tiles = new List<Tile>
        {
            new Tile("grass", true, 1.0),
            new Tile("dirt", true, 1.0),
        };
    }
}
