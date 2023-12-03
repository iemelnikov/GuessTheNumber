namespace GuessTheNumber
{
    /// <summary>
    /// Интерфейс ввода / вывода от пользователя
    /// </summary>
    internal interface IUserInputOutput: IOutput
    {
        /// <summary>
        /// Функция получения числового значения от пользователя
        /// </summary>
        /// <returns>Целочисленное число, введённое пользователем, если это null - пользователь ввёл нечисловое значение</returns>
        public int? GetIntegerValueFromUser();
    }
}
