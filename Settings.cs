namespace GuessTheNumber
{
    internal abstract class Settings
    {
        private IUserInputOutput _userInputOutput;

        public IUserInputOutput UserInputOutput { get { return _userInputOutput; } }


        public Settings(IUserInputOutput userInputOutput)
        {
            _userInputOutput = userInputOutput;
        }

        public virtual void LoadSettings()
        {

        }
    }
}
