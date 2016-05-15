using DevFlash.Mocking.TestableCode.IO;
using DevFlash.Mocking.Tests.Logging;

namespace DevFlash.Mocking.Tests.Mocking.IO
{
    internal class MockFileWrapperWithEventLog : IFileWrapper
    {
        private readonly EventLogger eventLogger;
        private bool existsToReturn;

        public MockFileWrapperWithEventLog(EventLogger eventLogger)
        {
            this.eventLogger = eventLogger;
        }

        public void SetExistsToReturn(bool value)
        {
            this.existsToReturn = value;
        }

        public bool Exists(string path)
        {
            return existsToReturn;
        }

        public void Delete(string path)
        {
            eventLogger.Log(Enums.EventType.FileDelete, path);
        }

        public IStreamWriterWrapper CreateToRead(string path)
        {
            eventLogger.Log(Enums.EventType.FileCreate, path);
            return new MockStreamWriterWrapperWithEventLog(eventLogger);
        }
    }
}
