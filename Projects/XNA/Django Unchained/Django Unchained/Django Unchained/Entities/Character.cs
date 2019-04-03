using System.Collections.Generic;
using Django_Unchained.Levels;
using Django_Unchained.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    /// <summary>
    /// Базовый класс для всех персонажей в игре
    /// </summary>
    public abstract class Character : Entity
    {
        #region Properties

        private int healthPoints;
        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                if (value < healthPoints)
                {
                    if (this is Django)
                    {
                        MusicPlayer.PlaySoundEffect(hurtSoundEffect);
                    }
                    isHeat = true;
                }
                if (value <= 100)
                {
                    healthPoints = value;
                }
                else if (value > 100)
                {
                    healthPoints = 100;
                }

                if (healthPoints <= 0)
                {
                    Game.Components.Remove(this);
                    if (this is Django)
                    {
                        Game.Components.Add(new Message(Game, ContentContainer.youDiedTexture2D));
                    }
                }
            }
        }
        public int JumpSpeed { get; protected set; }
        public int MoveSpeed { get; protected set; }
        protected double JumpHeight { get; set; }
        public int AllBullets
        {
            get
            {
                return iWeapon.AllBullets;
            }
            set
            {
                iWeapon.AllBullets = value;
            }
        }

        public Point FrameSizePoint { get; set; }

        public int CurrentBulletsInCharger
        {
            get { return iWeapon.CurrentBulletsInCharger; }
        }
        #endregion

        #region Fields
        protected Vector2 speedVector2;
        private int startJumpPositionY;
        protected readonly IWeapon iWeapon;

        private readonly SoundEffect shotSoundEffect;
        private readonly SoundEffect hurtSoundEffect;
        #endregion

        protected Character(Game game, Texture2D texture2D, Point frameSizePoint, Point coordinatesPoint, int squareSize, SoundEffect shotSoundEffect, SoundEffect hurtSoundEffect, IWeapon iWeapon)
            : base(game, texture2D)
        {
            this.shotSoundEffect = shotSoundEffect;
            MoveSpeed = 5;
            JumpHeight = ScreenHeight / 2.5;
            JumpSpeed = 2*FallSpeed;
            PositionRectangle = new Rectangle(squareSize * coordinatesPoint.X, squareSize * coordinatesPoint.Y, 0, 0);
            this.iWeapon = iWeapon;
            FrameSizePoint = frameSizePoint;
            this.hurtSoundEffect = hurtSoundEffect;
        }

        public override void Update(GameTime gameTime)
        {
            //CollisionWithPlatforms();
            rectangle = new Rectangle(FrameSizePoint.X * currentFrame.X, FrameSizePoint.Y * currentFrame.Y,
                FrameSizePoint.X, FrameSizePoint.Y);
            IsCollisionWithLimitOfScreen();
            PositionRectangle = new Rectangle(PositionRectangle.X + (int) speedVector2.X,
                PositionRectangle.Y + (int) speedVector2.Y, rectangle.Width, rectangle.Height);
            base.Update(gameTime);
        }

        #region Weapon

        protected void UseWeapon(MoveDirection weaponMoveDirection)
        {
            MusicPlayer.PlaySoundEffect(iWeapon.CurrentBulletsInCharger > 0
                ? shotSoundEffect
                : ContentContainer.emptySoundEffect);
            iWeapon.CurrentMoveDirection = weaponMoveDirection; 
            iWeapon.UseWeapon(PositionRectangle, GetType());
        }

        protected void Recharge()
        {
            iWeapon.IsRecharging = true;
        }
        #endregion

        #region MoveMethods

        protected virtual void Move(GameTime gameTime, int firstFrame, int lastFrame)
        {
            switch (CurrentMoveDirection)
            {
                case MoveDirection.None:
                    speedVector2 = Vector2.Zero;
                    break;
                case MoveDirection.Right:
                    speedVector2.X = MoveSpeed;
                    break;
                case MoveDirection.Left:
                    speedVector2.X = -MoveSpeed;
                    break;
            }
            Animation(gameTime, firstFrame, lastFrame);
        }

        protected void Jump()
        {
            if (startJumpPositionY == 0)
            {
                startJumpPositionY = PositionRectangle.Y;
            }
            else if ((startJumpPositionY - PositionRectangle.Y) < JumpHeight)
            {
                PositionRectangle = new Rectangle(PositionRectangle.X, PositionRectangle.Y - JumpSpeed, PositionRectangle.Width, PositionRectangle.Height);
            }
            else
            {
                StopJump();
            }
        }

        public void StopJump()
        {
            speedVector2.Y = 0;
            IsJump = false;
            startJumpPositionY = 0;
        }

        #endregion

        #region Collisions

        protected void CollisionWithGameObject(KeyValuePair<Entity, KindOfCollision> entity)
        {
            var immovableObject = entity.Key;
            var kindOfCollision = entity.Value;
            if (kindOfCollision == KindOfCollision.Top)
            {
                EntityHigherThanOtherEntity(immovableObject);
            }
            //джанго находится снизу
            if (kindOfCollision == KindOfCollision.Bottom)
            {
                StopJump();
            }
            //джанго слева и двигается вправо или джанго справа и двигается влево
            else if ((kindOfCollision == KindOfCollision.Left) || (kindOfCollision == KindOfCollision.Right))
            {
                speedVector2 = Vector2.Zero;
                StopJump();
            }
        }

        protected bool IsCollisionWithLimitOfScreen()
        {
            if (((PositionRectangle.Left <= 0) && (CurrentMoveDirection == MoveDirection.Left)) ||
                ((PositionRectangle.Right > Level.Length) && (CurrentMoveDirection == MoveDirection.Right)))
            {
                speedVector2.X = 0;
                return true;
            }
            return false;
        }

        #endregion
    }
}
