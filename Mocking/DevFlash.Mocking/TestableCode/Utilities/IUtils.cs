using DevFlash.Mocking.TestableCode.Config;
using DevFlash.Mocking.TestableCode.DateAndTime;
using DevFlash.Mocking.TestableCode.IO;

namespace DevFlash.Mocking.TestableCode.Utilities
{
    public interface IUtils
    {
        IFileWrapper FileWrapper { get; }

        IPathWrapper PathWrapper { get; }

        IConfigProvider ConfigProvider { get; }

        IDateTimeProvider DateTimeProvider { get; }
    }
}
