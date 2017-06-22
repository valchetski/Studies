using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    class Grenade : Entity
    {
        /// <summary>
        /// Урон от пули
        /// </summary>
        private readonly int damage;

        private Vector2 speedVector2;

        private readonly int speedY;
        private readonly int speedX;

        private readonly TimeSpan timeToBang;
        private TimeSpan currentTime;
        public MoveDirection MoveDirection
        {
            set
            {
                if (value == MoveDirection.Right)
                {
                    speedVector2 = new Vector2(speedX, -speedY);
                }
                else if (value == MoveDirection.Left)
                {
                    speedVector2 = new Vector2(-speedX, -speedY);
                }
            }
        }

        private readonly int maxHeight;//максимальная высота, на которую взлетит граната
        private int previousHeight;
        private int currentHeight;

        /// <summary>
        /// Зона поражения взрывом
        /// </summary>
        public Rectangle BangRectangle { get; private set; }
        private readonly int radiusExplosion;

        private bool isBang;

        private readonly SoundEffect explosionSoundEffect;

        public Grenade(Game game, Texture2D texture2D, SoundEffect explosionSoundEffect)
            : base(game, texture2D)
        {
            PositionRectangle = new Rectangle(0,0,texture2D.Width, texture2D.Height);
            damage = 25;
            speedY = 15;
            speedX = 10;
            maxHeight = Game.GraphicsDevice.Viewport.Height/6;
            timeToBang = new TimeSpan(0,0,3);
            currentTime = new TimeSpan(0,0,0);
            IsGravity = true;
            radiusExplosion = 100;
            this.explosionSoundEffect = explosionSoundEffect;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Bang(gameTime);
            CollisionWithPlatforms();
            if (speedVector2 == Vector2.Zero)
            {
                var centerOfGrenade = PositionRectangle.Center;
                BangRectangle = new Rectangle(centerOfGrenade.X - radiusExplosion, centerOfGrenade.Y - radiusExplosion,
                    2*radiusExplosion, 2*radiusExplosion);
            }
            base.Update(gameTime);
        }

        private void Move()
        {
            if (previousHeight == 0)
            {
                previousHeight = PositionRectangle.Top;
            }
            currentHeight += previousHeight - PositionRectangle.Top;
            previousHeight = PositionRectangle.Top;
            if (currentHeight >= maxHeight)
            {
                speedVector2.Y = 0;
            }
            PositionRectangle = new Rectangle(PositionRectangle.X + (int) speedVector2.X,
                PositionRectangle.Y + (int) speedVector2.Y, PositionRectangle.Width,
                PositionRectangle.Height);
        }

        private void Bang(GameTime gameTime)
        {
            currentTime += gameTime.ElapsedGameTime;
            if (currentTime >= timeToBang)
            {
                isBang = true;
            }
            if (isBang)
            {
                MusicPlayer.PlaySoundEffect(explosionSoundEffect);
                Collisions();
                Game.Components.Add(new Explosion(Game, ContentContainer.explosionTexture2D, BangRectangle, new Point(80, 80)));
            }
        }

        private void Collisions()
        {
            for (int i = 0; i < Game.Components.Count(); i++)
            {
                var gameObject = Game.Components[i];
                if (gameObject is Enemy)
                {
                    if (BangRectangle.Intersects(((Enemy)gameObject).PositionRectangle))
                    {
                        ((Enemy)gameObject).HealthPoints -= damage;
                    }
                }
                else if (gameObject is Django)
                {
                    if (BangRectangle.Intersects(((Django)gameObject).PositionRectangle))
                    {
                        ((Django)gameObject).HealthPoints -= damage;
                    }
                }
                else if (gameObject is PowderKeg)
                {
                    if (BangRectangle.Intersects(((PowderKeg)gameObject).PositionRectangle))
                    {
                        ((PowderKeg)gameObject).Bang(); //взорвали бочку
                    }
                }
            }
            Game.Components.Remove(this);
        }

        private void CollisionWithPlatforms()
        {
            var collidedEntitiesDictionary = CollisionWithEntities().Where(e => e.Key is Platform);
            foreach (var collidedEntity in collidedEntitiesDictionary)
            {
                var kindOfCollision = collidedEntity.Value;
                if (kindOfCollision == KindOfCollision.Top)
                {
                    EntityHigherThanOtherEntity(collidedEntity.Key);
                    speedVector2 = Vector2.Zero;
                }
                else if (kindOfCollision == KindOfCollision.Bottom)
                {
                    speedVector2.Y = 0;
                }
                else if ((kindOfCollision == KindOfCollision.Left) || (kindOfCollision == KindOfCollision.Right))
                {
                    speedVector2 = Vector2.Zero;
                }
                else if(kindOfCollision == KindOfCollision.Contain)
                {
                    PositionRectangle = new Rectangle(PositionRectangle.X - 2*PositionRectangle.Width, PositionRectangle.Y, PositionRectangle.Width, PositionRectangle.Height);
                }
            }
        }
    }
}
