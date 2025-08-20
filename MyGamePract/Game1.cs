using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGamePract
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player sprite;
        Texture2D spritesheet;
        AnimationManager am;

        private SpriteFont font;
        int score = 0;
        bool isPressed = false;


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
            am = new(2, 2, new Vector2(32, 32))
            {
                OffsetX = 32,
                OffsetY = 32,
            };
            Texture2D playerTexture = Content.Load<Texture2D>("Boy down sprite");
            sprite = new Player(playerTexture, new Vector2(200, 200));

            font = Content.Load<SpriteFont>("Fonts/spritefont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            sprite.Update(gameTime);
            am.Update(sprite.isMoving);

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !isPressed)
            {
                score++;
                isPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space) && isPressed)
            {
                isPressed = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //sprite.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, "Hello, World", Vector2.Zero, Color.White);

            _spriteBatch.DrawString(font, $"Pressed counter: {score}", new Vector2(100, 100), Color.AliceBlue);
            _spriteBatch.Draw(
               spritesheet,
               new Rectangle((int)sprite.position.X, (int)sprite.position.Y, 100, 100),
               am.GetFrame(),
               Color.White
               );
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
