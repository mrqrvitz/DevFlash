using System;

using DevFlash.AAA.Interfaces;

namespace DevFlash.AAA.Tests.Stubs
{
    public class StubDateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentTime { get; private set; }

        public StubDateTimeProvider(DateTime startTime)
        {
            this.CurrentTime = startTime;
        }

        public DateTime Now()
        {
            return this.CurrentTime;
        }
    }
}
