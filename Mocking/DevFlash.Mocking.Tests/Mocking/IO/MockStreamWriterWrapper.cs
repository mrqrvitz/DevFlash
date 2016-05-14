using System.Collections.Generic;
using DevFlash.Mocking.TestableCode.IO;

namespace DevFlash.Mocking.Tests.Mocking.IO
{
    internal class MockStreamWriterWrapper : IStreamWriterWrapper
    {
        private readonly List<string> writtenLines = new List<string>();

        public List<string> WrittenLines
        {
            get { return writtenLines; }
        }

        public void WriteLine(string value)
        {
            writtenLines.Add(value);
        }

        public void Dispose()
        {
        }
    }
}
