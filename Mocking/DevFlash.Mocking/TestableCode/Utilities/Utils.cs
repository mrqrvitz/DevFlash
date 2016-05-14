using DevFlash.Mocking.TestableCode.Config;
using DevFlash.Mocking.TestableCode.DateAndTime;
using DevFlash.Mocking.TestableCode.IO;

namespace DevFlash.Mocking.TestableCode.Utilities
{
    internal class Utils : IUtils
    {
        private readonly FileWrapper fileWrapper = new FileWrapper();
        private readonly PathWrapper pathWrapper = new PathWrapper();
        private readonly ConfigProvider configProvider = new ConfigProvider();
        private readonly DateTimeProvider dateTimeProvider = new DateTimeProvider();

        public IFileWrapper FileWrapper
        {
            get { return fileWrapper; }
        }

        public IPathWrapper PathWrapper
        {
            get { return pathWrapper; }
        }

        public IConfigProvider ConfigProvider
        {
            get { return configProvider; }
        }

        public IDateTimeProvider DateTimeProvider
        {
            get { return dateTimeProvider; }
        }
    }
}
