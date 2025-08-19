using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGamePract
{
    internal class Player : Sprite
    {

        public bool isMoving { get; set; }
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState state = Keyboard.GetState();
            isMoving = false; // assume not moving at start of frame

            if (state.IsKeyDown(Keys.Right))
            {
                position.X += 1;
                isMoving = true;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                position.X -= 1;
                isMoving = true;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                position.Y += 1;
                isMoving = true;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                position.Y -= 1;
                isMoving = true;
            }
        }


        //public override void Draw(SpriteBatch spriteBatch, Texture2D texture)
        //{

        //}
    }
}
