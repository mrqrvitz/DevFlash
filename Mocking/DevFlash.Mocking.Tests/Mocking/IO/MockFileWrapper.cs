using DevFlash.Mocking.TestableCode.IO;

namespace DevFlash.Mocking.Tests.Mocking.IO
{
    internal class MockFileWrapper : IFileWrapper
    {
        private bool existsToReturn;

        public string CreatedFilePath { get; private set; }

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
        }

        public IStreamWriterWrapper CreateToRead(string path)
        {
            this.CreatedFilePath = path;
            return new MockStreamWriterWrapper();
        }
    }
}
