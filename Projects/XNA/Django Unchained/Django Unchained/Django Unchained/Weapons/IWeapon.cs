using System;
using Microsoft.Xna.Framework;

namespace Django_Unchained.Weapons
{
    public interface IWeapon
    {
        MoveDirection CurrentMoveDirection { get; set; }
        TimeSpan TimeForRecharge { get; set; }
        bool IsRecharging { get; set; }
        int CurrentBulletsInCharger { get; set; }
        int AllBullets { get; set; }
        void UseWeapon(Rectangle positionRectangle, Type whoIsShootingType);
    }
}
