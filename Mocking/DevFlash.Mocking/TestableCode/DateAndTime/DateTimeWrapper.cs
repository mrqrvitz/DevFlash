using System;

namespace DevFlash.Mocking.TestableCode.DateAndTime
{
    public static class DateTimeWrapper
    {
        private static bool overrideDefaultNow;
        private static DateTime overridenNow;

        public static DateTime OverridenNow
        {
            set
            {
                overrideDefaultNow = true;
                overridenNow = value;
            }
        }

        public static DateTime Now
        {
            get
            {
                if (overrideDefaultNow)
                {
                    return overridenNow;
                }

                return DateTime.Now;
            }
        }
    }
}
