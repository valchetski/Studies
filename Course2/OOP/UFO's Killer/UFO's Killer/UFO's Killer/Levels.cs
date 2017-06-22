using System.Collections.Generic;

namespace UFO_s_Killer
{
    class Levels : List<Level>
    {
        public Level currentLevel;
        public bool isEndGame;


        public Levels()
        {
            isEndGame = false;
            const int ufoCountIncrement = 3;
            const int speedIncrement = 1;
            const int maxLevelCount = 5;
            currentLevel = new Level();
            Add(currentLevel);
            var currentUfoCount = currentLevel.ufoCount;
            var currentMinSpeed = currentLevel.minSpeed;
            var currentMaxSpeed = currentLevel.maxSpeed;
            var currentLevelCount = currentLevel.number;
            for (var i = 1; i < maxLevelCount; i++)
            {
                currentLevelCount++;
                currentUfoCount += ufoCountIncrement;
                currentMinSpeed += speedIncrement;
                currentMaxSpeed += speedIncrement;
                Add(new Level(currentLevelCount, currentUfoCount, currentMinSpeed, currentMaxSpeed));
            }
        }

        public void NextLevel()
        {
            var indexOfCurrentLevel = IndexOf(currentLevel);
            if (indexOfCurrentLevel < (Count - 1))
            {
                currentLevel = this[indexOfCurrentLevel + 1];
            }
            else
            {
                isEndGame = true;
                currentLevel = null;
            }
        }

        public void NewGame()
        {
            currentLevel = this[0];
            isEndGame = false;
        }
    }
}
