using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UFO_s_Killer
{
    class Sight : GameObject
    {
        public Sight(Texture2D _texture2D, Rectangle _rectangle)
        {
            texture2D = _texture2D;
            rectangle = _rectangle;
        }

        public override void Update(int screenWidth, int screenHeigth)
        {
            rectangle.X =  Mouse.GetState().X;
            rectangle.Y = Mouse.GetState().Y;
        }
    }
}
