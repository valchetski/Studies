using Django_Unchained.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    /// <summary>
    /// Пуля
    /// </summary>
    public class Bullet : Entity
    {
        private readonly int speed;
        private int speedX;
        private readonly int damage;
        public MoveDirection MoveDirection
        {
            set
            {
                if (value == MoveDirection.Left)
                {
                    speedX = - speed;
                }
                else if (value == MoveDirection.Right)
                {
                    speedX = speed;
                }
                CurrentMoveDirection = value;
            }
        }

        private bool isKilledDjango;

        public bool IsKilledDjango
        {
            get { return isKilledDjango; }
            set
            {
                isKilledDjango = value;
                isKilledEnemy = !value;
            }
        }

        private bool isKilledEnemy;

        public bool IsKilledEnemy
        {
            get { return isKilledEnemy; }
            set
            {
                isKilledEnemy = value;
                isKilledDjango = !value;
            }
        }

        public Bullet(Game game, Texture2D texture2D)
            : base(game, texture2D)
        {
            PositionRectangle = new Rectangle(0,0,texture2D.Width, texture2D.Height);
            speed = 8;
            IsGravity = false;
            damage = 5;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Collisions();
            base.Update(gameTime);
        }

        private void Move()
        {
            PositionRectangle = new Rectangle(PositionRectangle.X + speedX, PositionRectangle.Y, PositionRectangle.Width,
                PositionRectangle.Height);
        }

        private void Collisions()
        {
            if ((PositionRectangle.X < 0) || (PositionRectangle.X > Level.Length))
            {
                Game.Components.Remove(this);
            }
            else
            {
                var collidedEntities = CollisionWithEntities();
                foreach (var entity in collidedEntities)
                {
                    if (entity.Key is Platform)
                    {
                        Game.Components.Remove(this);
                    }
                    else if ((entity.Key is Enemy) && isKilledEnemy)
                    {
                        ((Enemy)entity.Key).HealthPoints -= damage;
                        Game.Components.Remove(this);
                    }
                    else if ((entity.Key is Django) && isKilledDjango)
                    {
                        ((Django)entity.Key).HealthPoints -= damage;
                        Game.Components.Remove(this);
                    }//если стреляет враг, то он не может взорвать бочку с порохом
                    else if ((entity.Key is PowderKeg) && isKilledEnemy)
                    {
                        ((PowderKeg)entity.Key).Bang(); //взорвали бочку
                        Game.Components.Remove(this); 
                    }
                }
            }
        }
    }
}
