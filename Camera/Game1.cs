using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Camera
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> sprites;
        private Texture2D playerTexture;
        private Texture2D textureBlock;
        private Player player;
        //private FollowCamera camera;
        private YSortCamera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            sprites = new();
            camera = new(Vector2.Zero);
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
            playerTexture = Content.Load<Texture2D>("player");
            textureBlock = Content.Load<Texture2D>("ground");

            for (int i = 0; i < 10; i++)
            {
                sprites.Add(
                    new Sprite(textureBlock, new (i * 32, i * 32, 32, 32), new (0, 0, 32, 32))
                );
            }
            player = new Player(playerTexture, new(100, 100, 64, 64), new(0, 0, 32, 32));

            sprites.Add(
                player
            );
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (Sprite sprite in sprites)
            {
                sprite.Update();
            }
            camera.Follow(player.drect, new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            //foreach(Sprite sprite in sprites)
            //{
            //    sprite.Draw(_spriteBatch, camera.position);
            //}

            camera.Draw(_spriteBatch, sprites);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
