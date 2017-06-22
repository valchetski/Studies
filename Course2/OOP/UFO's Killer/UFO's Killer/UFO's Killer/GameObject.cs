using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UFO_s_Killer
{
    class GameObject
    {
        public Texture2D texture2D;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
        public virtual void  Update(int screenWidth, int screenHeigth){}

    }
}
