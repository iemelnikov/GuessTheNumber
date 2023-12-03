using System.Reflection;

namespace GuessTheNumber
{
    internal class LogOutput : IOutput
    {

        public void OutputMessage(string logMessage)
        {
            var asmLocation = Assembly.GetExecutingAssembly().Location;
            if (!string.IsNullOrEmpty(asmLocation))
            {
                string? exePath = Path.GetDirectoryName(asmLocation);
                try
                {
                    using (StreamWriter w = File.AppendText($"{exePath}\\log.txt"))
                    {
                        Log(logMessage, w);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}: {logMessage}");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
