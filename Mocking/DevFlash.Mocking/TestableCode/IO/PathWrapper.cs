using System.IO;

namespace DevFlash.Mocking.TestableCode.IO
{
    internal class PathWrapper : IPathWrapper
    {
        public string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }
    }
}
