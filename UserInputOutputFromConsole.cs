namespace GuessTheNumber
{
    internal class UserInputOutputFromConsole : IUserInputOutput
    {
        public int? GetIntegerValueFromUser()
        {
            string? userInputValue = Console.ReadLine();
            if (int.TryParse(userInputValue, out int result))
            {
                return result;
            }
            else
                Console.WriteLine("Было указано нечисловое значение.");
            return null;
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
