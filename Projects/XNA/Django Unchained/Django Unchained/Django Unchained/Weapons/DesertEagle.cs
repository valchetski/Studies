using System;
using Django_Unchained.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Weapons
{
    class DesertEagle : GameComponent, IWeapon
    {
        #region Properties
        public MoveDirection CurrentMoveDirection { get; set; }
        public int AllBullets
        {
            get
            {
                if (Bullets != null)
                {
                    return Bullets.Number;
                }
                return 0;
            }
            set
            {
                Bullets.Number = value;
            }
        }
        /// <summary>
        /// Время на перезарядку обоймы
        /// </summary>
        public TimeSpan TimeForRecharge { get; set; }
        /// <summary>
        /// Список всех пулей персонажа
        /// </summary>
        protected Bullets Bullets { get; set; }

        /// <summary>
        /// ТЕКУЩЕЕ количество пуль в обойме
        /// </summary>
        public int CurrentBulletsInCharger { get; set; }
        #endregion

        /// <summary>
        /// Количество пуль в полной обойме
        /// </summary>
        private readonly int bulletsInCharger;

        public bool IsRecharging { get; set; }
        private TimeSpan timer;

        public DesertEagle(Game game, Texture2D bulletTexture2D) : base(game)
        {
            CurrentBulletsInCharger = bulletsInCharger = 10;
            TimeForRecharge = new TimeSpan(0, 0, 1);
            Bullets = new Bullets(game, bulletTexture2D, AllBullets);
            AllBullets = 20;
            timer = TimeSpan.Zero;
            IsRecharging = false;
            CurrentMoveDirection = MoveDirection.Right;
            Game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (IsRecharging)
            {
                Recharge(gameTime);
            }
            base.Update(gameTime);
        }

        public void UseWeapon(Rectangle positionRectangle, Type whoIsShootingType)
        {
            if ((Bullets.Count > 0) && (CurrentBulletsInCharger > 0))
            {
                var bullet = Bullets[0];
                Bullets.Remove(bullet);
                bullet.MoveDirection = CurrentMoveDirection;
                bullet.PositionRectangle = new Rectangle(positionRectangle.X + positionRectangle.Width/2,
                    positionRectangle.Y + positionRectangle.Height/2, bullet.PositionRectangle.Width,
                    bullet.PositionRectangle.Height);
                if (whoIsShootingType == typeof (Django))
                {
                    bullet.IsKilledEnemy = true;
                }
                else if (whoIsShootingType == typeof (Enemy))
                {
                    bullet.IsKilledDjango = true;
                }
                Game.Components.Add(bullet);
                CurrentBulletsInCharger--;
            }
        }

        private void Recharge(GameTime gameTime)
        {
            if (timer < TimeForRecharge)
            {
                timer += TimeSpan.FromMilliseconds(gameTime.ElapsedGameTime.Milliseconds);
            }
            else
            {
                if (AllBullets >= bulletsInCharger)
                {
                    CurrentBulletsInCharger = bulletsInCharger;
                }
                timer = TimeSpan.Zero;
                IsRecharging = false;
            }
        }
    }
}
