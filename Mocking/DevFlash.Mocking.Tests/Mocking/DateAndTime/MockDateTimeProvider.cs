using System;
using DevFlash.Mocking.TestableCode.DateAndTime;

namespace DevFlash.Mocking.Tests.Mocking.DateAndTime
{
    internal class MockDateTimeProvider : IDateTimeProvider
    {
        private readonly DateTime now;

        public MockDateTimeProvider(DateTime now)
        {
            this.now = now;
        }

        public DateTime Now
        {
            get { return now; }
        }
    }
}
