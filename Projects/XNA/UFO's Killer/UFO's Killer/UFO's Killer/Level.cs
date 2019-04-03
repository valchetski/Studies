namespace UFO_s_Killer
{
    class Level
    {
        public int number;
        public int ufoCount;
        public int minSpeed;
        public int maxSpeed;

        public Level(int _number, int _ufoCount, int _minSpeed, int _maxSpeed)
        {
            number = _number;
            ufoCount = _ufoCount;
            minSpeed = _minSpeed;
            maxSpeed = _maxSpeed;
        }

        public Level()
        {
            number = 1;
            ufoCount = 5;
            minSpeed = 1;
            maxSpeed = 2;
        }
    }
}
