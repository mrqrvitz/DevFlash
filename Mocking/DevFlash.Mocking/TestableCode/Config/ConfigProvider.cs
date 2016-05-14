using System.Configuration;

namespace DevFlash.Mocking.TestableCode.Config
{
    internal class ConfigProvider : IConfigProvider
    {
        public string OutputFolderPath
        {
            get { return GetConfigEntry(ConfigConstants.OutputFolderPath); }
        }

        private string GetConfigEntry(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
