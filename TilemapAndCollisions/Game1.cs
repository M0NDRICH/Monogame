using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace TilemapAndCollisions
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D terrainTexture;
        private Texture2D hitboxTexture;

        private Vector2 camera;

        private Dictionary<Vector2, int> mg;
        private Dictionary<Vector2, int> fg;
        private Dictionary<Vector2, int> collisions;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            fg = LoadMap("../../../Data/level1_fg.csv");
            mg = LoadMap("../../../Data/level1_mg.csv");
            collisions = LoadMap("../../../Data/level1_collisions.csv");
            camera = Vector2.Zero;
        }

        private Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();

            StreamReader reader = new(filepath);

            int y = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');

                for (int x  = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        if (value > -1)
                        {
                            result[new Vector2(x, y)] = value;
                        }
                    }
                }

                y++;

            }

            return result;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            terrainTexture = Content.Load<Texture2D>("terrain");
            hitboxTexture = Content.Load<Texture2D>("tilesetter");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camera.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camera.X += 5;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            // TODO: Add your drawing code here
            int display_tilesize = 64;
            int num_tiles_per_row = 32;
            int pixel_tilesize = 32;

            foreach(var item in mg)
            {
                Rectangle drect = new(
                    (int)item.Key.X * display_tilesize + (int)camera.X,
                    (int)item.Key.Y * display_tilesize + (int)camera.Y,
                    display_tilesize,
                    display_tilesize
                );

                int x = item.Value % num_tiles_per_row;
                int y = item.Value / num_tiles_per_row;

                Rectangle src = new(
                    x * pixel_tilesize,
                    y * pixel_tilesize,
                    pixel_tilesize,
                    pixel_tilesize
                );

                _spriteBatch.Draw(terrainTexture, drect, src, Color.White);
            }

            foreach (var item in fg)
            {
                Rectangle drect = new(
                    (int)item.Key.X * display_tilesize + (int)camera.X,
                    (int)item.Key.Y * display_tilesize + (int)camera.Y,
                    display_tilesize,
                    display_tilesize
                );

                int x = item.Value % num_tiles_per_row;
                int y = item.Value / num_tiles_per_row;

                Rectangle src = new(
                    x * pixel_tilesize,
                    y * pixel_tilesize,
                    pixel_tilesize,
                    pixel_tilesize
                );

                _spriteBatch.Draw(terrainTexture, drect, src, Color.White);
            }

            foreach (var item in collisions)
            {
                Rectangle drect = new(
                    (int)item.Key.X * display_tilesize + (int)camera.X,
                    (int)item.Key.Y * display_tilesize + (int)camera.Y,
                    display_tilesize,
                    display_tilesize
                );

                int x = item.Value % num_tiles_per_row;
                int y = item.Value / num_tiles_per_row;

                Rectangle src = new(
                    x * pixel_tilesize,
                    y * pixel_tilesize,
                    pixel_tilesize,
                    pixel_tilesize
                );

                _spriteBatch.Draw(hitboxTexture, drect, src, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
