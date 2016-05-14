using System.Collections.Generic;

namespace DevFlash.Mocking.Tests.Logging
{
    internal class EventLogger
    {
        public readonly List<Event> Events = new List<Event>();

        public void Log(Enums.EventType eventType, string parameter)
        {
            var logEvent = new Event
            {
                EventType = eventType,
                Parameter = parameter
            };

            Events.Add(logEvent);
        }
    }
}
