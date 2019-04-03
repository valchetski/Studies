using System;
using Microsoft.Xna.Framework;

namespace Django_Unchained.SaveAndLoad
{
    [Serializable]
    public class SavingObject
    {
        public int healthPoints;
        public int allBullets;
        public Rectangle positionRectangle;
        public Vector2 positonVector2;
        public Point frameSizePoint;

        public int leftScreenX;//Только для Level
        public int length;     //
        public int currentLevel;

        public Type type;

        public SavingObject(int healthPoints, int allBullets, Rectangle positionRectangle, int leftScreenX, int length, int currentLevel,
            Point frameSizePoint, Type type)
        {
            this.healthPoints = healthPoints;
            this.allBullets = allBullets;
            this.positionRectangle = positionRectangle;

            this.leftScreenX = leftScreenX;
            this.length = length;
            this.currentLevel = currentLevel;

            this.frameSizePoint = frameSizePoint;
            this.type = type;
        }

        public SavingObject() { }
    }
}
