namespace GuessTheNumber
{
    internal class GuessTheNumberGameInjector
    {
        public Game ResolveGame()
        {
            var userInputOutput = new UserInputOutputFromConsole();
            var numbToBeGuessedSettings = new TheNumberToBeGuessedSettings(userInputOutput);
            numbToBeGuessedSettings.LoadSettings();
            var numbGen = new RandomNumberGenerator(numbToBeGuessedSettings.MinValue, numbToBeGuessedSettings.MaxValue);
            var logOutput = new LogOutput();
            Game game = new GuessTheNumberGame(numbToBeGuessedSettings, numbGen, userInputOutput, logOutput);
            return game;
        }
    }
}
