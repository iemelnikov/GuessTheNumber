namespace GuessTheNumber
{
    /// <summary>
    /// Класс игры "Угадай число"
    /// </summary>
    internal class GuessTheNumberGame : Game
    {
        private INumberGenerator _numbGen;

        public INumberGenerator NumbGen { get { return _numbGen; } }

        public GuessTheNumberGame(TheNumberToBeGuessedSettings settings, INumberGenerator NumbGen, IUserInputOutput userInputOutput, IOutput logOutput) : base(settings, userInputOutput, logOutput)
        {
            _numbGen = NumbGen;
        }

        public override void Play()
        {
            // Генерируем число для отгадывания.
            int theNumberToBeGuessed = NumbGen.Generate();
            TheNumberToBeGuessedSettings NumbToBeGuessedSettings = (TheNumberToBeGuessedSettings)Settings;
            for (int i = 1; i <= NumbToBeGuessedSettings.NumberOfAttemps; i++)
            {
                string outputMessage = $"Попытка отгадывания {i} из {NumbToBeGuessedSettings.NumberOfAttemps}.";
                OutputMessageToAllOutputs(outputMessage);
                int? theGuessedNumberFromUser;
                do
                {
                    UserInputOutput.OutputMessage($"Угадайте загаданное число в диапазоне от {NumbToBeGuessedSettings.MinValue} до {NumbToBeGuessedSettings.MaxValue}:");
                    theGuessedNumberFromUser = UserInputOutput.GetIntegerValueFromUser();
                } while (!theGuessedNumberFromUser.HasValue) ;
                if (theGuessedNumberFromUser == theNumberToBeGuessed)
                {
                    outputMessage = $"Вы верно угадали загаданное число {theNumberToBeGuessed}!";
                    OutputMessageToAllOutputs(outputMessage);
                    break;
                }
                else
                {
                    if (i == NumbToBeGuessedSettings.NumberOfAttemps)
                        outputMessage = $"К сожалению, вы не отгадали загаданное число. Это было число {theNumberToBeGuessed}!";
                    else
                        outputMessage = $"Загаданное число {(theGuessedNumberFromUser > theNumberToBeGuessed ? "мен" : "бол")}ьше вашего варианта ({theGuessedNumberFromUser})!";
                    OutputMessageToAllOutputs(outputMessage);
                }
            }
        }

        private void OutputMessageToAllOutputs(string outputMessage)
        {
            foreach (IOutput output in GetAllOutputs())
            {
                output.OutputMessage(outputMessage);
            }
        }
    }
}
