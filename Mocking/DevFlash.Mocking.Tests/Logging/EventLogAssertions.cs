using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFlash.Mocking.Tests.Logging
{
    internal class EventLogAssertions
    {
        private readonly EventLogger eventLogger;

        private List<Event> Events
        {
            get { return eventLogger.Events; }
        }

        public EventLogAssertions(EventLogger eventLogger)
        {
            this.eventLogger = eventLogger;
        }

        public void Occurred(Enums.EventType expectedEventType)
        {
            var occurred = Events.Any(x => x.EventType == expectedEventType);

            Assert.IsTrue(occurred, "Expected event of type {0} to occur but it didn't.", expectedEventType);
        }

        public void Occurred(Enums.EventType expectedEventType, string expectedParameter)
        {
            var occurred = Events.Any(x => x.EventType == expectedEventType && x.Parameter == expectedParameter);

            Assert.IsTrue(occurred, "Expected event of type {0} with parameter '{1}' to occur but it didn't.",
                expectedEventType, expectedParameter);
        }

        public void OccurredTimes(Enums.EventType expectedEventType, int expectedOccurrences)
        {
            var occurrences = Events.Count(x => x.EventType == expectedEventType);

            Assert.AreEqual(expectedOccurrences, occurrences,
                "Expected event of type {0} to occur {1} times but it occurred {2} times.", expectedEventType,
                expectedOccurrences, occurrences);
        }

        public void DidNotOccur(Enums.EventType expectedEventType)
        {
            var occurred = Events.Any(x => x.EventType == expectedEventType);
            Assert.IsFalse(occurred, "Expected event of type {0} to not occur but it did.", expectedEventType);
        }

        public void DidNotOccur(Enums.EventType expectedEventType, string expectedParameter)
        {
            var occurred = Events.Any(x => x.EventType == expectedEventType);

            Assert.IsFalse(occurred, "Expected event of type {0} with parameter '{1}' to not occur but it did.",
                expectedEventType, expectedParameter);
        }

        public void EventHappenedBefore(Enums.EventType expectedPreviousEventType,
            Enums.EventType expectedLaterEventType)
        {
            var previousEventIndex = GetIndexOfEvent(expectedPreviousEventType);
            var laterEventIndex = GetIndexOfEvent(expectedLaterEventType);

            Assert.IsTrue(previousEventIndex < laterEventIndex,
                "Expected event of type {0} to happen before event of type {1}, but it didn't",
                expectedPreviousEventType, expectedLaterEventType);
        }

        private int GetIndexOfEvent(Enums.EventType eventType)
        {
            var index = Events.FindIndex(x => x.EventType == eventType);

            if (index == -1)
            {
                Assert.Fail("Did not log event of type {0}", eventType);
            }

            return index;
        }
    }
}
