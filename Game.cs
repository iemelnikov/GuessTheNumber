namespace GuessTheNumber
{
    internal abstract class Game
    {
        private Settings _settings;
        
        public Settings Settings { get { return _settings; } }

        private IUserInputOutput _userInputOutput;

        public IUserInputOutput UserInputOutput { get { return _userInputOutput; } }

        private IOutput _logOutput;

        public IOutput LogOutput { get { return _logOutput; } }

        public Game(Settings settings, IUserInputOutput userInputOutput, IOutput logOutput)
        {
            _settings = settings;
            _userInputOutput = userInputOutput;
            _logOutput = logOutput;
        }

        public virtual void Play()
        {
        }

        public IEnumerable<IOutput> GetAllOutputs() 
        {
            return new List<IOutput>() { UserInputOutput, LogOutput };
        }
    }
}
