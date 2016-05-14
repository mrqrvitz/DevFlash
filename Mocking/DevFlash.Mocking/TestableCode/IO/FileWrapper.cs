using System.IO;

namespace DevFlash.Mocking.TestableCode.IO
{
    internal class FileWrapper : IFileWrapper
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public IStreamWriterWrapper CreateToRead(string path)
        {
            using (var fileStream = File.Create(path))
            using (var streamWriter = new StreamWriter(fileStream))
            {
                return new StreamWriterWrapper(streamWriter);
            }
        }
    }
}
