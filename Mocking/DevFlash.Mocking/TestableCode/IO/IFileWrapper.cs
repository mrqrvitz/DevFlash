namespace DevFlash.Mocking.TestableCode.IO
{
    public interface IFileWrapper
    {
        bool Exists(string path);

        void Delete(string path);

        IStreamWriterWrapper CreateToRead(string path);
    }
}
