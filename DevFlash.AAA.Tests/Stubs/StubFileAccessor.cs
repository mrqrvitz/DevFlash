using DevFlash.AAA.Interfaces;

namespace DevFlash.AAA.Tests.Stubs
{
    public class StubFileAccessor : IFileAccessor
    {
        public bool ExistsResult { get; set; }

        public string ReadResult { get; set; }

        public string DeletedPath { get; private set; }

        public string RenamedPath { get; private set; }

        public bool Exists(string path)
        {
            return ExistsResult;
        }

        public string Read(string path)
        {
            return ReadResult;
        }

        public void Delete(string path)
        {
            this.DeletedPath = path;
        }

        public void Rename(string path, string newName)
        {
            this.RenamedPath = path;
        }
    }
}
