using System;
using System.Collections.Generic;
using DevFlash.Mocking.Model;
using DevFlash.Mocking.TestableCode;
using DevFlash.Mocking.Tests.Mocking.Config;
using DevFlash.Mocking.Tests.Mocking.DateAndTime;
using DevFlash.Mocking.Tests.Mocking.IO;
using DevFlash.Mocking.Tests.Mocking.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFlash.Mocking.Tests.Tests
{
    [TestClass]
    public class TimeStampTests
    {
        [TestMethod]
        public void GeneratesCorrectTimeStamp_UsingDateTimeProvider()
        {
            const int Day = 14, Month = 5, Year = 2015, Hours = 11, Minutes = 17, Seconds = 34;
            const string ExpectedTimeStampDate = "14-05-2015";
            const string ExpectedTimeStampTime = "111734";

            var dateTimeNow = new DateTime(Year, Month, Day, Hours, Minutes, Seconds);

            var dateTimeProvider = new MockDateTimeProvider(dateTimeNow);

            var products = new List<Product>();
            var productRepository = new MockProductRepository(products);

            var configProvider = new MockConfigProvider();
            var fileWrapper = new MockFileWrapper();
            var pathWrapper = new MockPathWrapper();

            var testableClass = new TestableClass(productRepository, dateTimeProvider, configProvider, fileWrapper,
                pathWrapper);

            testableClass.SaveProductsLog();

            var createdFilePath = fileWrapper.CreatedFilePath;

            Assert.IsTrue(createdFilePath.Contains(ExpectedTimeStampDate));
            Assert.IsTrue(createdFilePath.Contains(ExpectedTimeStampTime));
        }

        [TestMethod]
        public void GeneratesCorrectTimeStamp_UsingDateTimeWrapper()
        {
            throw new NotImplementedException("TODO");
        }
    }
}
