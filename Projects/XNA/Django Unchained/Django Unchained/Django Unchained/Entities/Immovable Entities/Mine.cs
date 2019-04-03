using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities.Immovable_Entities
{
    public class Mine : ImmovableObject
    {
        private readonly int radiusExplosion;
        private readonly int damage;
        private readonly SoundEffect explosionEffect;
        private bool isActivate;
        private readonly SoundEffect timerSoundEffect;
        private readonly TimeSpan timeToBang;
        private TimeSpan currentTime;
        public Rectangle BangRectangle { get; private set; }

        private int n;
        public Mine(Game game, Texture2D texture2D, Point coordinatesPoint, int squareSize, SoundEffect explosionEffect, SoundEffect timerSoundEffect)
            : base(game, texture2D, coordinatesPoint, squareSize)
        {
            n = 1;
            radiusExplosion = 100;
            damage = 50;
            timeToBang = new TimeSpan(0,0,timerSoundEffect.Duration.Seconds);
            this.explosionEffect = explosionEffect;
            this.timerSoundEffect = timerSoundEffect;
        }

        public void Activate()
        {
            if (isActivate != true)
            {
                isActivate = true;
                MusicPlayer.PlaySoundEffect(timerSoundEffect);
            }
        }


        public override void Update(GameTime gameTime)
        {
            if (isActivate)
            {
                Bang(gameTime);
            }
            CollisionWithPlatforms();

            base.Update(gameTime);
        }

        private void Bang(GameTime gameTime)
        {
            currentTime += gameTime.ElapsedGameTime;
            if (currentTime > new TimeSpan(0, 0, n*1))
            {
                isHeat = true;
                n++;
            }
            else
            {
                isHeat = false;
            }

            if (currentTime >= timeToBang)
            {
                var centerOfGrenade = PositionRectangle.Center;
                BangRectangle = new Rectangle(centerOfGrenade.X - radiusExplosion, centerOfGrenade.Y - radiusExplosion,
                    2 * radiusExplosion, 2 * radiusExplosion);
                MusicPlayer.PlaySoundEffect(explosionEffect);
                Collisions();
                Game.Components.Add(new Explosion(Game, ContentContainer.explosionTexture2D, BangRectangle, new Point(80, 80)));
            }
        }

        private void Collisions()
        {
            for (int i = 0; i < Game.Components.Count(); i++)
            {
                if (Game.Components[i].GetType() == typeof(Enemy))
                {
                    if (BangRectangle.Intersects(((Enemy)Game.Components[i]).PositionRectangle))
                    {
                        ((Enemy)Game.Components[i]).HealthPoints -= damage;
                    }
                }
                else if (Game.Components[i].GetType() == typeof(Django))
                {
                    if (BangRectangle.Intersects(((Django)Game.Components[i]).PositionRectangle))
                    {
                        ((Django)Game.Components[i]).HealthPoints -= damage;
                    }
                }
                else if (Game.Components[i].GetType() == typeof(PowderKeg))
                {
                    if (BangRectangle.Intersects(((PowderKeg)Game.Components[i]).PositionRectangle))
                    {
                        ((PowderKeg)Game.Components[i]).Bang(); //взорвали бочку
                    }
                }
            }
            Game.Components.Remove(this);
        }

        private void CollisionWithPlatforms()
        {
            var collidedEntitiesDictionary = CollisionWithEntities();
            foreach (var collidedEntity in collidedEntitiesDictionary)
            {
                var kindOfCollision = collidedEntity.Value;
                if (kindOfCollision == KindOfCollision.Top)
                {
                    EntityHigherThanOtherEntity(collidedEntity.Key);
                }
            }
        }
    }
}
