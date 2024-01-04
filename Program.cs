namespace GuessTheNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            var injector = new GuessTheNumberGameInjector();
            Game game = injector.ResolveGame();
            game.Play();
        }
    }
}
