using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tennis
{
    class Action
    {
        public void Collision(ref Ball ball, ref Racket racket)
        {
            if (racket.rectangle.Intersects(ball.rectangle))
            {
                var coordinate = ball.rectangle.X + ball.texture.Width;
                if ((racket.rectangle.X <= coordinate + 5) && (racket.rectangle.X >= coordinate - 5) && (ball.rectangle.X < racket.rectangle.X))
                {
                    ball.speedVector2.X = -ball.speedVector2.X;
                    ball.speedVector2.Y = -ball.speedVector2.Y;
                }
                else if ((racket.rectangle.X + racket.texture.Width <= ball.rectangle.X + 5) && (racket.rectangle.X + racket.texture.Width >= ball.rectangle.X - 5))
                {
                    ball.speedVector2.X = -ball.speedVector2.X;
                    ball.speedVector2.Y = -ball.speedVector2.Y;
                }
                else
                {
                    ball.speedVector2.Y = -ball.speedVector2.Y;
                }
            }
        }
        public void Collision(ref Ball ball, ref RacketComputer racketComputer)
        {
            if (racketComputer.rectangle.Intersects(ball.rectangle))
            {
                var coordinate = ball.rectangle.X + ball.texture.Width;
                if ((racketComputer.rectangle.X <= coordinate + 5) && (racketComputer.rectangle.X >= coordinate - 5) && (ball.rectangle.X < racketComputer.rectangle.X))
                {
                    ball.speedVector2.X = -ball.speedVector2.X;
                    ball.speedVector2.Y = -ball.speedVector2.Y;
                }
                else if ((racketComputer.rectangle.X + racketComputer.texture.Width <= ball.rectangle.X + 5) && (racketComputer.rectangle.X + racketComputer.texture.Width >= ball.rectangle.X - 5))
                {
                    ball.speedVector2.X = -ball.speedVector2.X;
                    ball.speedVector2.Y = -ball.speedVector2.Y;
                }
                else
                {
                    ball.speedVector2.Y = -ball.speedVector2.Y;
                }
            }
        }

        public bool isEndGame(Ball ball, int displayHeight)
        {
            if ((ball.rectangle.Y < 0) || (ball.rectangle.Y > displayHeight))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
