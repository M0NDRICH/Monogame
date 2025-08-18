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

        Texture2D spritesheet;

        int counter;
        int activeFrame;
        int numFrames;
        

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

            // TODO: use this.Content to load your game content here
            spritesheet = Content.Load<Texture2D>("player");

            activeFrame = 0;
            numFrames = 2;
            counter = 0;
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

                if (activeFrame == numFrames) 
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

            _spriteBatch.Draw(
                spritesheet,
                new Rectangle(100, 100, 100, 100),
                new Rectangle(activeFrame * 32 + 32, 64, 32, 32),
                Color.White
                );

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
