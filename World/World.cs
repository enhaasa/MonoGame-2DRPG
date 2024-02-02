using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace ArrPeeGee.World
{
    internal static class World
    {
        public static void Render(SpriteBatch _spriteBatch, List<Tile> tiles)
        {
            _spriteBatch.Begin();

            foreach (Tile tile in tiles)
            {
                _spriteBatch.Draw(
                    tile.Texture,
                    tile.Position,
                    null,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            }

            _spriteBatch.End();
        }

        public static List<Tile> GetTiles(ContentManager Content, List<Tile> tiles, int[] mapTileMap, int mapWidth)
        {
            List<Tile> tilesList = new List<Tile>();
            
            int row = 0;
            int col = 0;

            for (int i = 0; i < mapTileMap.Length; i++)
            {
                if (i % mapWidth == 0)
                {
                    if (i != 0)
                    {
                        row++;
                    }
                    col = 0;
                }
                else
                {
                    col++;
                }

                if (mapTileMap[i] >= tiles.Count || mapTileMap[i] < 0)
                {
                    continue;
                }

                Tile originalTile = tiles[mapTileMap[i]];
                originalTile.Texture = Content.Load<Texture2D>(originalTile.TextureName);

                Tile tileCopy = new Tile(
                    originalTile.TextureName, 
                    originalTile.IsTraversable, 
                    originalTile.SpeedAffect
                );

                tileCopy.Texture = originalTile.Texture;
                tileCopy.Position = new Vector2(col * originalTile.width, row * originalTile.height);

                tilesList.Add(tileCopy);
            }

            return tilesList;
        }
    }
}

