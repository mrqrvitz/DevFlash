using System;

namespace DevFlash.Mocking.TestableCode.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
