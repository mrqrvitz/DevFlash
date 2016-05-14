using DevFlash.Mocking.TestableCode.Config;

namespace DevFlash.Mocking.Tests.Mocking.Config
{
    internal class MockConfigProvider : IConfigProvider
    {
        public string OutputFolderPath
        {
            get { return "OutputFolderPath"; }
        }
    }
}
