namespace GuessTheNumber
{
    /// <summary>
    /// Класс игры "Угадай число"
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
            var rnd = new Random();
            var NumbToBeGuessedSettings = (TheNumberToBeGuessedSettings)Settings;
            // Получить случайное число:
            int theNumberToBeGuessed = rnd.Next(NumbToBeGuessedSettings.MinValue, NumbToBeGuessedSettings.MaxValue);
            for (int i = 1; i <= NumbToBeGuessedSettings.NumberOfAttemps; i++)
            {
                string outputMessage = $"Попытка отгадывания {i} из {NumbToBeGuessedSettings.NumberOfAttemps}.";
                foreach (var output in GetAllOutputs())
                {
                    output.OutputMessage(outputMessage);
                }
                int? theGuessedNumberFromUser;
                do
                {
                    UserInputOutput.OutputMessage($"Угадайте загаданное число в диапазоне от {NumbToBeGuessedSettings.MinValue} до {NumbToBeGuessedSettings.MaxValue}:");
                    theGuessedNumberFromUser = UserInputOutput.GetIntegerValueFromUser();
                } while (!theGuessedNumberFromUser.HasValue) ;
                if (theGuessedNumberFromUser == theNumberToBeGuessed)
                {
                    outputMessage = $"Вы верно угадали загаданное число {theNumberToBeGuessed}!";
                    foreach (var output in GetAllOutputs())
                    {
                        output.OutputMessage(outputMessage);
                    }
                    break;
                }
                else
                {
                    if (i == NumbToBeGuessedSettings.NumberOfAttemps)
                        outputMessage = $"К сожалению, вы не отгадали загаданное число. Это было число {theNumberToBeGuessed}!";
                    else
                        outputMessage = $"Загаданное число {(theGuessedNumberFromUser > theNumberToBeGuessed ? "мен" : "бол")}ьше вашего варианта ({theGuessedNumberFromUser})!";
                    foreach (var output in GetAllOutputs())
                    {
                        output.OutputMessage(outputMessage);
                    }
                }
            }
        }
    }
}
