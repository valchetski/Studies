using System;
using Django_Unchained.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Weapons
{
    class GrenadeWeapon : DrawableGameComponent, IWeapon
    {
        #region Fields

        public MoveDirection CurrentMoveDirection { get; set; }
        public int CurrentBulletsInCharger { get; set; }

        public bool IsRecharging { get; set; }
        public int AllBullets{get; set;}
        /// <summary>
        /// Время на перезарядку обоймы
        /// </summary>
        public TimeSpan TimeForRecharge { get; set; }
        /// <summary>
        /// Список всех пулей персонажа
        /// </summary>
        protected Grenades Grenades { get; set; }
        #endregion
        public GrenadeWeapon(Game game, Texture2D grenadeTexture2D)
            : base(game)
        {
            CurrentBulletsInCharger = 1;
            AllBullets = 5;
            TimeForRecharge = new TimeSpan(0, 0, 0, 2);
            Grenades = new Grenades(game, grenadeTexture2D, AllBullets);
        }

        public void UseWeapon(Rectangle positionRectangle, Type whoIsShootingType)
        {
            if (Grenades.Count > 0)
            {
                var grenade = Grenades[0];
                Grenades.Remove(grenade);
                grenade.MoveDirection = CurrentMoveDirection;
                grenade.PositionRectangle = new Rectangle(positionRectangle.X + positionRectangle.Width/2,
                    positionRectangle.Y + positionRectangle.Height/2, grenade.PositionRectangle.Width,
                    grenade.PositionRectangle.Height);
                Game.Components.Add(grenade);
            }
        }
    }
}
