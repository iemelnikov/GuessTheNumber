namespace GuessTheNumber
{
    internal class RandomNumberGenerator : INumberGenerator
    {
        private readonly int _minValue;
        /// <summary>
        /// Минимальное значение для генерируемого числа
        /// </summary>
        public int MinValue { get { return _minValue; } }

        private readonly int _maxValue;

        /// <summary>
        /// Максимальное значение для генерируемого числа
        /// </summary>
        public int MaxValue { get { return _maxValue; } }

        public RandomNumberGenerator(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int Generate()
        {
            var rnd = new Random();
            // Получить случайное число:
            return rnd.Next(MinValue, MaxValue);
        }
    }
}
