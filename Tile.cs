using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ArrPeeGee
{
    internal class Tile
    {
        public string TextureName { get; set; }
        public Texture2D Texture {  get; set; }   
        public Vector2 Position { get; set; }
        public bool IsTraversable { get; set; }
        public double SpeedAffect { get; set; }

        public Tile(string textureName, bool isTraversable, double speedAffect)
        {
            this.TextureName = textureName;
            this.IsTraversable = isTraversable;
            this.SpeedAffect = speedAffect;
        }

        readonly public int width = 32;
        readonly public int height = 32;
    }
}
