using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tennis
{
    class GameObject
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Vector2 speedVector2;
        protected int displayWidth;
        protected int displayHeight;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
