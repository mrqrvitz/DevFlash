using DevFlash.Mocking.TestableCode.IO;

namespace DevFlash.Mocking.Tests.Mocking.IO
{
    internal class MockPathWrapper : IPathWrapper
    {
        public string Combine(string path1, string path2)
        {
            return path1 + path2;
        }
    }
}
