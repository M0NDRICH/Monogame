﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement
{
    internal class ExitScene : IScene
    {
        private ContentManager contentManager;
        private Texture2D texture;
        public ExitScene(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }
        public void Load()
        {
        }
        public void Update(GameTime gameTime) { }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
