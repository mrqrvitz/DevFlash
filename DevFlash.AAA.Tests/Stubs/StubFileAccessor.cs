using System.Collections.Generic;

using DevFlash.AAA.Interfaces;

namespace DevFlash.AAA.Tests.Stubs
{
    public class StubFileAccessor : IFileAccessor
    {
        public bool ExistsResult { get; set; }

        public string ReadResult { get; set; }

        public bool CreatedFile { get; private set; }

        public string CreatedFilePath { get; private set; }

        public List<string> TextsWrittenToFile { get; private set; }

        public bool ClosedFile { get; private set; }

        public StubFileAccessor()
        {
            this.TextsWrittenToFile = new List<string>();
        }

        public bool Exists(string path)
        {
            return ExistsResult;
        }

        public void CreateFile(string path)
        {
            this.CreatedFilePath = path;
            this.CreatedFile = true;
        }

        public void WriteToFile(string path, string text)
        {
            this.TextsWrittenToFile.Add(text);
        }

        public void CloseFile(string path)
        {
            this.ClosedFile = true;
        }

        public string Read(string path)
        {
            return ReadResult;
        }
    }
}
