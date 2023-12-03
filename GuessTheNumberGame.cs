namespace GuessTheNumber
{
    /// <summary>
    /// Класс игры
    /// </summary>
    internal class GuessTheNumberGame : Game
    {
        public GuessTheNumberGame(TheNumberToBeGuessedSettings settings, IUserInputOutput userInputOutput, IOutput logOutput) : base(settings, userInputOutput, logOutput)
        {
        }

        public override void Play()
        {
            Settings.LoadSettings();
            // Генерируем число для отгадывания.
            Random Rnd = new Random();
            TheNumberToBeGuessedSettings NumbToBeGuessedSettings = (TheNumberToBeGuessedSettings)Settings;
            // Получить случайное число:
            int TheNumberToBeGuessed = Rnd.Next(NumbToBeGuessedSettings.MinValue, NumbToBeGuessedSettings.MaxValue);
            for (int i = 1; i <= NumbToBeGuessedSettings.NumberOfAttemps; i++)
            {
                string OutputMessage = $"Попытка отгадывания {i} из {NumbToBeGuessedSettings.NumberOfAttemps}.";
                foreach (var output in GetAllOutputs())
                {
                    output.OutputMessage(OutputMessage);
                }
                int? TheGuessedNumberFromUser;
                do
                {
                    UserInputOutput.OutputMessage($"Угадайте загаданное число в диапазоне от {NumbToBeGuessedSettings.MinValue} до {NumbToBeGuessedSettings.MaxValue}:");
                    TheGuessedNumberFromUser = UserInputOutput.GetIntegerValueFromUser();
                } while (!TheGuessedNumberFromUser.HasValue) ;
                if (TheGuessedNumberFromUser == TheNumberToBeGuessed)
                {
                    OutputMessage = $"Вы верно угадали загаданное число {TheNumberToBeGuessed}!";
                    foreach (var output in GetAllOutputs())
                    {
                        output.OutputMessage(OutputMessage);
                    }
                    break;
                }
                else
                {
                    if (i == NumbToBeGuessedSettings.NumberOfAttemps)
                        OutputMessage = $"К сожалению, вы не отгадали загаданное число. Это было число {TheNumberToBeGuessed}!";
                    else
                        OutputMessage = $"Загаданное число {(TheGuessedNumberFromUser > TheNumberToBeGuessed ? "мен" : "бол")}ьше вашего варианта ({TheGuessedNumberFromUser})!";
                    foreach (var output in GetAllOutputs())
                    {
                        output.OutputMessage(OutputMessage);
                    }
                }
            }
        }
    }
}
