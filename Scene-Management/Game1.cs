using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Scene_Management
{
    enum Scenes
    {
        START,
        GAME
    };

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Scenes activeScene;
        private Texture2D texture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            activeScene = Scenes.START;
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
            texture = Content.Load<Texture2D>("ground");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch(activeScene)
            {
                case Scenes.START:

                    // start scene
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        activeScene = Scenes.GAME;
                    }

                    break;
                case Scenes.GAME:

                    // game scene

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            switch (activeScene)
            {
                case Scenes.START:

                    // start scene

                    break;
                case Scenes.GAME:

                    // game scene
                    _spriteBatch.Draw(texture, new Rectangle(10, 10, 400, 400), new Rectangle(0, 0, 16, 16), Color.White);

                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
