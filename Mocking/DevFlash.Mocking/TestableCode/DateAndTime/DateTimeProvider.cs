using System;

namespace DevFlash.Mocking.TestableCode.DateAndTime
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
