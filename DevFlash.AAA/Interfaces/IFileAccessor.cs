namespace DevFlash.AAA.Interfaces
{
    public interface IFileAccessor
    {
        bool Exists(string path);

        void CreateFile(string path);

        void WriteToFile(string path, string text);

        void CloseFile(string path);
    }
}
