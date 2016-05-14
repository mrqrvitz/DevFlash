using System.IO;

namespace DevFlash.Mocking.TestableCode.IO
{
    internal class StreamWriterWrapper : IStreamWriterWrapper
    {
        private readonly StreamWriter streamWriter;

        public StreamWriterWrapper(StreamWriter streamWriter)
        {
            this.streamWriter = streamWriter;
        }

        public void WriteLine(string value)
        {
            streamWriter.WriteLine(value);
        }

        public void Dispose()
        {
            streamWriter.Dispose();
        }
    }
}
