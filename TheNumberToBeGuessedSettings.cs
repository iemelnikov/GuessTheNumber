namespace GuessTheNumber
{
    /// <summary>
    /// Класс настроек для загадываемого числа
    /// </summary>
    internal class TheNumberToBeGuessedSettings : Settings
    {
        private int _numberOfAttempts;
        /// <summary>
        /// Кол-во попыток отгадывания и диапазон чисел
        /// </summary>
        public int NumberOfAttemps { get { return _numberOfAttempts; } }

        private int _minValue;
        /// <summary>
        /// Минимальное значение для загадываемого числа
        /// </summary>
        public int MinValue { get { return Math.Min(_minValue, _maxValue); } }

        private int _maxValue;

        public TheNumberToBeGuessedSettings(IUserInputOutput userInputOutput) : base(userInputOutput)
        {
        }

        /// <summary>
        /// Максимальное значение для загадываемого числа
        /// </summary>
        public int MaxValue { get { return Math.Max(_maxValue, _minValue); } }

        public override void LoadSettings()
        {
            int? inputIntValue;
            // Задаём количество попыток отгадывания:
            do
            {
                UserInputOutput.OutputMessage("Укажите кол-во попыток отгадывания (> 0):");
                inputIntValue = UserInputOutput.GetIntegerValueFromUser();
                if (inputIntValue != null)
                    _numberOfAttempts = inputIntValue.Value;
            } while (!inputIntValue.HasValue || NumberOfAttemps <= 0);

            // Задаём диапазон для загадываемого числа:
            do
            {
                UserInputOutput.OutputMessage("Укажите минимальное значение для загадываемого числа:");
                inputIntValue = UserInputOutput.GetIntegerValueFromUser();
                if (inputIntValue != null)
                    _minValue = inputIntValue.Value;
            } while (!inputIntValue.HasValue);
            
            do
            {
                UserInputOutput.OutputMessage("Укажите максимальное значение для загадываемого числа:");
                inputIntValue = UserInputOutput.GetIntegerValueFromUser();
                if (inputIntValue != null)
                    _maxValue = inputIntValue.Value;
            } while (!inputIntValue.HasValue);
        }
    }
}
