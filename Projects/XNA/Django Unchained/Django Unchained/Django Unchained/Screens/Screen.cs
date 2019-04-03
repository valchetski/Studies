using Microsoft.Xna.Framework;

namespace Django_Unchained.Screens
{
    public abstract class Screen : DrawableGameComponent
    {
        protected Screen(Game game)
            : base(game)
        {
            
        }

        public abstract void Checked();
    }
}
