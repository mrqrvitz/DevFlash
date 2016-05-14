using System;

namespace DevFlash.Mocking.TestableCode.IO
{
    public interface IStreamWriterWrapper : IDisposable
    {
        void WriteLine(string value);
    }
}
