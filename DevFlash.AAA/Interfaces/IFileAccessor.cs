namespace DevFlash.AAA.Interfaces
{
    public interface IFileAccessor
    {
        bool Exists(string path);

        string Read(string path);

        void Delete(string path);

        void Rename(string path, string newName);
    }
}
