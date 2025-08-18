using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace PractMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Texture2D texture;
        //MovingSprite sprite;
        List<Sprite> sprites;
        Texture2D[] runningTextures;

        int counter;
        int activeFrame;

        Player player;

        bool space_pressed = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
             sprites = new();

            // TODO: use this.Content to load your game content here
            
            runningTextures = new Texture2D[2];

            runningTextures[0] = Content.Load<Texture2D>("Boy right sprite");
            runningTextures[1] = Content.Load<Texture2D>("Boy right sprite2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            counter++;

            if (counter > 29)
            {
                counter = 0;
                activeFrame++;

                if (activeFrame > runningTextures.Length -1)
                {
                    activeFrame = 0;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(runningTextures[activeFrame], new Rectangle(100, 100, 100, 100), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
