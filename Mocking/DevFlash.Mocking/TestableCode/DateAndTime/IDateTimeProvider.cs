using System;

namespace DevFlash.Mocking.TestableCode.DateAndTime
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
