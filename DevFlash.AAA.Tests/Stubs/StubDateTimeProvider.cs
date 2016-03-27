using System;

using DevFlash.AAA.Interfaces;

namespace DevFlash.AAA.Tests.Stubs
{
    public class StubDateTimeProvider : IDateTimeProvider
    {
        private readonly TimeSpan incrementationSpan;

        private DateTime currentTime;

        public StubDateTimeProvider(DateTime startTime, TimeSpan incrementationSpan)
        {
            this.currentTime = startTime;
            this.incrementationSpan = incrementationSpan;
        }

        public DateTime Now()
        {
            var time = this.currentTime;
            this.currentTime = this.currentTime.Add(incrementationSpan);

            return time;
        }
    }
}
