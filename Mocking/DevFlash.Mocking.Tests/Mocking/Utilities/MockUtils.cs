using System;
using DevFlash.Mocking.TestableCode.Config;
using DevFlash.Mocking.TestableCode.DateAndTime;
using DevFlash.Mocking.TestableCode.IO;
using DevFlash.Mocking.TestableCode.Utilities;
using DevFlash.Mocking.Tests.Mocking.Config;
using DevFlash.Mocking.Tests.Mocking.DateAndTime;
using DevFlash.Mocking.Tests.Mocking.IO;

namespace DevFlash.Mocking.Tests.Mocking.Utilities
{
    internal class MockUtils : IUtils
    {
        private readonly MockFileWrapper fileWrapper = new MockFileWrapper();
        private readonly MockPathWrapper pathWrapper = new MockPathWrapper();
        private readonly MockConfigProvider configProvider = new MockConfigProvider();
        private readonly MockDateTimeProvider dateTimeProvider;

        public MockUtils(DateTime now)
        {
            this.dateTimeProvider = new MockDateTimeProvider(now);
        }

        public IFileWrapper FileWrapper
        {
            get { return fileWrapper; }
        }

        public IPathWrapper PathWrapper
        {
            get { return pathWrapper; }
        }

        public IConfigProvider ConfigProvider
        {
            get { return configProvider; }
        }

        public IDateTimeProvider DateTimeProvider
        {
            get { return dateTimeProvider; }
    }
}
}
