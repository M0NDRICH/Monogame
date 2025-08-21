using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement
{
    internal class GameScene : IScene
    {
        private ContentManager contentManager;
        private SceneManager sceneManager;
        private Texture2D texture;
        public GameScene(ContentManager contentManager, SceneManager sceneManager) 
        {
            this.contentManager = contentManager;
            this.sceneManager = sceneManager;
        }
        public void Load()
        {
            texture = contentManager.Load<Texture2D>("ground");
        }
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                sceneManager.AddScene(new ExitScene(contentManager));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(10, 10, 400, 400), new(0, 0, 32, 32), Color.White);
        }
    }
}
