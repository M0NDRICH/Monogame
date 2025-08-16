using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractMonogame
{
    internal class Player : Sprite
    {
        List<Sprite> collisionGroup;
        public Player(Texture2D texture, Vector2 position, List<Sprite> collisionGroup) : base(texture, position)
        {
            this.collisionGroup = collisionGroup;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float changeX = 0;
            float changeY = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                changeX += 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                changeX -= 1;
            }
            position.X += changeX;

            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.X -= changeX;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                changeY -= 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                changeY += 1;
            }
            position.Y += changeY;

            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.Y -= changeY;
                }
            }
        }
    }
}
