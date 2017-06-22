using System;
using System.Linq;
using Django_Unchained.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    public class Enemy : Character
    {
        private Rectangle operatingZone;
        private int operatingRadius;

        private TimeSpan timer;
        private TimeSpan timeForRecharge;
        public Enemy(Game game, Texture2D texture2D, Point frameSizePoint, Point coordinatesPoint, int squareSize, SoundEffect shotSoundEffect, SoundEffect hurtSoundEffect, IWeapon iWeapon)
            : base(game, texture2D, frameSizePoint, coordinatesPoint, squareSize, shotSoundEffect, hurtSoundEffect, iWeapon)
        {
            Initialization();
        }

        public Enemy(Game game)
            : base(
                game, ContentContainer.enemyTexture2D, new Point(0, 0), new Point(0, 0), 0, ContentContainer.shotEnemySoundEffect,
                ContentContainer.hurtSoundEffect, new DesertEagle(game, ContentContainer.bulletTexture2D))
        {
            Initialization();
        }

        private void Initialization()
        {
            MoveSpeed = 2;
            operatingRadius = 250;
            timeForRecharge = new TimeSpan(0, 0, 0, 1);
            HealthPoints = 10;
            IsAnimate = true;
        }

        public override void Update(GameTime gameTime)
        {
            RunFromGrenade();
            Movement(gameTime);
            ShotDjango(gameTime);
            Collisions();
            base.Update(gameTime);
        }

        private void ShotDjango(GameTime gameTime)
        {
            operatingZone = new Rectangle(PositionRectangle.Center.X - operatingRadius, PositionRectangle.Y,
                2 * operatingRadius, PositionRectangle.Height);
            var django = (Django) Game.Components.FirstOrDefault(c => c.GetType() == typeof (Django));
            if ((django != null) && django.PositionRectangle.Intersects(operatingZone))
            {
                if ((timer == TimeSpan.Zero) && 
                    (((django.PositionRectangle.X > PositionRectangle.X) && (CurrentMoveDirection == MoveDirection.Right)) ||
                   ((django.PositionRectangle.X < PositionRectangle.X) && (CurrentMoveDirection == MoveDirection.Left))))
                {
                        UseWeapon(CurrentMoveDirection);
                }
                timer += gameTime.ElapsedGameTime;
                if (timer >= timeForRecharge)
                {
                    timer = TimeSpan.Zero;
                }
            }
        }

        private void Collisions()
        {
            var collidedEntities = CollisionWithEntities();

            foreach (var entity in collidedEntities)
            {
                if ((entity.Key is Platform) || (entity.Key is Django))
                {
                    CollisionWithGameObject(entity);
                }

                if (entity.Key is Platform)
                {
                    //CheckForDownfall((Platform)entity.Key);
                }
            }
        }

        /// <summary>
        /// Потом учесть то, что гранат может быть несколько
        /// </summary>
        private void RunFromGrenade()
        {
            var grenade = (Grenade) Game.Components.FirstOrDefault(c => c is Grenade);
            if ((grenade != null) && (PositionRectangle.Intersects(grenade.BangRectangle)))
            {
                CurrentMoveDirection = PositionRectangle.Center.X >= grenade.BangRectangle.Center.X
                    ? MoveDirection.Right
                    : MoveDirection.Left;
            }
        }

        #region Pursuit
        private void Movement(GameTime gameTime)
        {
            //скорость равна нулю, когда враг во что-нибудь упирается
            //поэтому он пойдет в другую сторону
            if (speedVector2 == Vector2.Zero)
            {
                if (CurrentMoveDirection == MoveDirection.Left)
                {
                    CurrentMoveDirection = MoveDirection.Right;
                }
                else if (CurrentMoveDirection == MoveDirection.Right)
                {
                    CurrentMoveDirection = MoveDirection.Left;
                }
            }

            switch (CurrentMoveDirection)
            {
                case MoveDirection.Right:
                    CanEnemyMove();
                    base.Move(gameTime, 0, 2);
                    break;
                case MoveDirection.Left:
                    CanEnemyMove();
                    base.Move(gameTime, 3, 5);
                    break;
            }
        }

        private void CanEnemyMove()
        {
            CheckForDownfallLeft();
            CheckForDownfallRight();
        }

        void CheckForDownfall(Platform platform)
        {
            var nextRectangle = new Rectangle(0,0,0,0);
            Rectangle pr;
            if (CurrentMoveDirection == MoveDirection.Right)
            {
                nextRectangle = new Rectangle(PositionRectangle.X + PositionRectangle.Width, PositionRectangle.Y,
                    PositionRectangle.Width, PositionRectangle.Height);
                pr = new Rectangle(platform.PositionRectangle.X + platform.PositionRectangle.Width,
                    platform.PositionRectangle.Y, platform.PositionRectangle.Width, platform.PositionRectangle.Height);
            }
            else if (CurrentMoveDirection == MoveDirection.Left)
            {
                nextRectangle = new Rectangle(PositionRectangle.X - PositionRectangle.Width, PositionRectangle.Y,
                    PositionRectangle.Width, PositionRectangle.Height);
            }
           /* var cha = Game.Components.Where(c => c is Platform)
                .Cast<Platform>()
                .Where(p => p.PositionRectangle.Intersects(nextRectangle));
            if (cha.Count() < 0)
            {
                if (CurrentMoveDirection == MoveDirection.Left)
                {
                    CurrentMoveDirection = MoveDirection.Right;
                    isBanLeft = true;
                }
                if (CurrentMoveDirection == MoveDirection.Right)
                {
                    CurrentMoveDirection = MoveDirection.Left;
                }
            }*/
        }

        /// <summary>
        /// Проверяет или упадет персонаж в пропасть при дальнейшем движении влево  
        /// </summary>
        void  CheckForDownfallLeft()
        {
            var chaRectangle = PositionRectangle;
            PositionRectangle = new Rectangle(PositionRectangle.X - PositionRectangle.Width, PositionRectangle.Y,
                PositionRectangle.Width, PositionRectangle.Height);
            int collisionWithChoosenSide = CollisionWithEntities().Count(p => p.Value == KindOfCollision.Top);

            if ((collisionWithChoosenSide == 0) && (CurrentMoveDirection == MoveDirection.Left))
            {
                CurrentMoveDirection = MoveDirection.Right;
            }
            PositionRectangle = chaRectangle;
        }

        void CheckForDownfallRight()
        {
            var chaRectangle = PositionRectangle;
            PositionRectangle = new Rectangle(PositionRectangle.X + PositionRectangle.Width, PositionRectangle.Y,
                PositionRectangle.Width, PositionRectangle.Height);
            int collisionWithChoosenSide = CollisionWithEntities().Count(p => p.Value == KindOfCollision.Top);

            if ((collisionWithChoosenSide == 0) && (CurrentMoveDirection == MoveDirection.Right))
            {
                CurrentMoveDirection = MoveDirection.Left;
            }
            PositionRectangle = chaRectangle;
        }
        #endregion
    }
}
