using System.Collections.Generic;

namespace ArrPeeGee
{
    internal class Map
    {
        public string Name { get; set; }
        public int[] BackgroundTileMap { get; set; }
        public int[] ForegroundTileMap { get; set; }

        public List<Tile> BackgroundTiles { get; set; }
        public List<Tile> ForegroundTiles { get; set; }
    }
}
