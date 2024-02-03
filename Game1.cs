using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using ArrPeeGee.World;
using System;
using ArrPeeGee.Entities;

namespace ArrPeeGee
{
    public class Game1 : Game
    {
        List<Map> maps = new List<Map>();
        int currentMapIndex = 0;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640; 
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            string mapsPath = "../../../Maps/";

            string json = File.ReadAllText(Path.Combine(mapsPath, "start.json"));
            Map map1 = JsonConvert.DeserializeObject<Map>(json);

            List<Tile> backgroundTiles = World.World.GetTiles(Content, Background.tiles, map1.BackgroundTileMap, 20);
            List<Tile> foregroundTiles = World.World.GetTiles(Content, Foreground.tiles, map1.ForegroundTileMap, 20);
            map1.BackgroundTiles = backgroundTiles;
            map1.ForegroundTiles = foregroundTiles;
            maps.Add(map1);

            Player.Character = new Character(_spriteBatch, Content.Load<Texture2D>("character"), new Vector2(100, 100));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keyState = Keyboard.GetState();

            Player.HandleInput(keyState, gameTime, maps[currentMapIndex]);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            World.World.Render(_spriteBatch, maps[currentMapIndex].BackgroundTiles);
            World.World.Render(_spriteBatch, maps[currentMapIndex].ForegroundTiles);

            Player.Character.Render(gameTime);

            base.Draw(gameTime);
        }
    }
}
