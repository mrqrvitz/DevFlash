using System;

namespace DevFlash.Mocking.TestableCode.DateTimeProvider
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
