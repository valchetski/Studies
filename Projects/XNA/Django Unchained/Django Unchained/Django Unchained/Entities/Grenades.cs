using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    class Grenades : List<Grenade>
    {
        public Grenades(Game game, Texture2D texture2D, int allBullets) 
        {
            for (var i = 0; i < allBullets; i++)
            {
                Add(new Grenade(game, texture2D, ContentContainer.grenadeExplosionSoundEffect));
            }
        }
    }
}
