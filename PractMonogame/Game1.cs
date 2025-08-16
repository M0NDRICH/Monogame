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
            //Texture2D texture = Content.Load<Texture2D>("Boy down sprite");
            //sprite = new MovingSprite(texture, Vector2.Zero, 1f);
            Texture2D playerTexture = Content.Load<Texture2D>("Boy down sprite");
            Texture2D enemyTexture = Content.Load<Texture2D>("Boy right sprite2");

            //sprites.Add(new Sprite(enemyTexture, new Vector2(100, 100)));
            sprites.Add(new Sprite(enemyTexture, new Vector2(400, 200)));
            //sprites.Add(new Sprite(enemyTexture, new Vector2(700, 300)));

            player = new Player(playerTexture, new Vector2(0, 200), sprites);

            sprites.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            List<Sprite> killList = new();
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);

                if (sprite.Rect.Intersects(player.Rect))
                {
                    killList.Add(sprite);
                }
            }
            //player.Update(gameTime); 

            //foreach (var sprite in killList)
            //{
            //    sprites.Remove(sprite);
            //}

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
            foreach (var sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }
            //player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
