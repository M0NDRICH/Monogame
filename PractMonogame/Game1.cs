using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PractMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Texture2D texture;
        //MovingSprite sprite;
        List<MovingSprite> sprites;

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
            Texture2D texture = Content.Load<Texture2D>("Boy down sprite");
            //sprite = new MovingSprite(texture, Vector2.Zero, 1f);
            sprites = new List<MovingSprite>();

            for (int i = 0; i < 10; i++)
            {
                sprites.Add(new MovingSprite(texture, new Vector2(0, 10*i), i));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //sprite.Update();
            foreach (MovingSprite sprite in sprites)
            {
                sprite.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            //_spriteBatch.Draw(texture, new Rectangle(100, 100, 200, 200), Color.White);
            //_spriteBatch.Draw(texture, new Vector2(100, 100), Color.White);
            //_spriteBatch.Draw(sprite.texture, sprite.Rect, Color.White);
            foreach (MovingSprite sprite in sprites)
            {
                _spriteBatch.Draw(sprite.texture, sprite.Rect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
