using System.Collections.Generic;
using DevFlash.Mocking.TestableCode.IO;
using DevFlash.Mocking.Tests.Logging;

namespace DevFlash.Mocking.Tests.Mocking.IO
{
    internal class MockStreamWriterWrapperWithEventLog : IStreamWriterWrapper
    {
        private readonly List<string> writtenLines = new List<string>();
        private readonly EventLogger eventLogger;

        public MockStreamWriterWrapperWithEventLog(EventLogger eventLogger)
        {
            this.eventLogger = eventLogger;
        }

        public List<string> WrittenLines
        {
            get { return writtenLines; }
        }

        public void WriteLine(string value)
        {
            eventLogger.Log(Enums.EventType.FileWrite, value);
            writtenLines.Add(value);
        }

        public void Dispose()
        {
        }
    }
}
