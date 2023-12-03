namespace GuessTheNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userInputOutput = new UserInputOutputFromConsole();
            var logOutput = new LogOutput();
            var numbToBeGuessedSettings = new TheNumberToBeGuessedSettings(userInputOutput);
            Game game = new GuessTheNumberGame(numbToBeGuessedSettings, userInputOutput, logOutput);
            game.Play();
        }
    }
}
