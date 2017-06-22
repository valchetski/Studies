using System;
using System.Collections.Generic;
using System.Linq;
using Django_Unchained.Bars;
using Django_Unchained.Entities.Bonuses;
using Django_Unchained.Entities.Immovable_Entities;
using Django_Unchained.Entities.Immovable_Entities.Bonuses;
using Django_Unchained.Levels;
using Django_Unchained.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Django_Unchained.Entities
{
    public class Django : Character
    {
        private KeyboardState pastKey;

        private Keys pastKeyMove;

        private TimeSpan lifeTimeOfSpeedBonus;
        private int previousMoveSpeed;

        protected IWeapon otherIWeapon;
        public Django(Game game, Texture2D texture2D, Point frameSizePoint, Point coordinatesPoint, int squareSize, SoundEffect shotSoundEffect, SoundEffect hurtSoundEffect, IWeapon iWeapon, IWeapon otherIWeapon)
            : base(game, texture2D, frameSizePoint, coordinatesPoint, squareSize, shotSoundEffect, hurtSoundEffect, iWeapon)
        {
            Initialization(otherIWeapon);
        }

        public Django(Game game, IWeapon otherIWeapon) : base(game, ContentContainer.djangoTexture2D, new Point(0,0), new Point(0,0), 0, ContentContainer.shotDjangoSoundEffect, ContentContainer.hurtSoundEffect, new DesertEagle(game, ContentContainer.bulletTexture2D))
        {
            Initialization(otherIWeapon);
        }

        private void Initialization(IWeapon newOtherIWeapon)
        {
            HealthPoints = 70;
            CurrentMoveDirection = MoveDirection.Right;
            IsAnimate = true;
            pastKeyMove = Keys.Right;
            previousMoveSpeed = MoveSpeed;
            otherIWeapon = newOtherIWeapon;
        }

        public override void Update(GameTime gameTime)
        {
            var presentKey = Keyboard.GetState();
            var isKeyPress = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Move(gameTime, 0, 2);
                isKeyPress = true;
                CurrentMoveDirection = MoveDirection.Right;
                pastKeyMove = Keys.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Move(gameTime, 3, 5);
                isKeyPress = true;
                CurrentMoveDirection = MoveDirection.Left;
                pastKeyMove = Keys.Left;
            }
            if ((presentKey.IsKeyDown(Keys.F)) && (pastKey.IsKeyUp(Keys.F)))
            {
                UseWeapon(pastKeyMove == Keys.Left ? MoveDirection.Left : MoveDirection.Right);
            }
            if ((presentKey.IsKeyDown(Keys.G)) && (pastKey.IsKeyUp(Keys.G)))
            {
                UseOtherWeapon(pastKeyMove == Keys.Left ? MoveDirection.Left : MoveDirection.Right);
            }
            if ((presentKey.IsKeyDown(Keys.R)) && (pastKey.IsKeyUp(Keys.R)))
            {
                Recharge();
            }
            if ((presentKey.IsKeyDown(Keys.Up)) && (pastKey.IsKeyUp(Keys.Up)))
            {
                if (IsInAir == false)
                {
                    IsJump = true;
                }
                isKeyPress = true;
                CurrentMoveDirection = MoveDirection.Up;
            }

            if (IsJump)
            {
                Jump();
            }
            if ((isKeyPress == false))
            {
                speedVector2 = Vector2.Zero;
            }

            if (lifeTimeOfSpeedBonus <= TimeSpan.Zero)
            {
                MoveSpeed = previousMoveSpeed;
                lifeTimeOfSpeedBonus = TimeSpan.Zero;
            }
            else
            {
                lifeTimeOfSpeedBonus -= gameTime.ElapsedGameTime;
            }
            pastKey = presentKey;
            
            ChangePointsInBulletsBar();
            ChangePointsInHealthBar();

            Level.CheckForNextLevel(this, Game.Components.Count(e => e is Enemy));

            Collisions();
            base.Update(gameTime);
        }

        private void ChangePointsInBulletsBar()
        {
            BulletsBar.allBullets = AllBullets - CurrentBulletsInCharger;
            BulletsBar.points = CurrentBulletsInCharger;
        }

        private void ChangePointsInHealthBar()
        {
            HealthBar.points = HealthPoints;
        }

        private void Collisions()
        {
            var collidedEntities = CollisionWithEntities();

            foreach (var entity in collidedEntities)
            {
                if ((entity.Key is Platform) || (entity.Key is PowderKeg) || (entity.Key is Enemy))
                {
                    CollisionWithGameObject(entity);
                }
                else if (entity.Key is Cactus)
                {
                    CollisionWithCactus(entity);
                }
                else if (entity.Key is HealthBonus)
                {
                    HealthPoints += ((HealthBonus)entity.Key).GetBonus();
                }
                else if (entity.Key is BulletsBonus)
                {
                    AllBullets += ((BulletsBonus)entity.Key).GetBonus();
                }
                else if (entity.Key is SpeedBonus)
                {
                    var bonus = ((SpeedBonus)entity.Key).GetBonus();
                    MoveSpeed *= bonus.Key;
                    lifeTimeOfSpeedBonus = bonus.Value;
                }
                else if (entity.Key is Mine)
                {
                    ((Mine)entity.Key).Activate();
                }
            }
        }

        protected void CollisionWithCactus(KeyValuePair<Entity, KindOfCollision> entity)
        {
            var kindOfCollision = entity.Value;
            ((Cactus)entity.Key).Prick(kindOfCollision, this);
        }

        private void UseOtherWeapon(MoveDirection weaponMoveDirection)
        {
            otherIWeapon.CurrentMoveDirection = weaponMoveDirection;
            otherIWeapon.UseWeapon(PositionRectangle, GetType());
        }
    }
}
