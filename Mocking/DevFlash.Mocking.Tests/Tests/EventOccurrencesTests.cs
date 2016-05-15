using System;
using System.Collections.Generic;
using DevFlash.Mocking.Model;
using DevFlash.Mocking.TestableCode;
using DevFlash.Mocking.Tests.Logging;
using DevFlash.Mocking.Tests.Mocking.Config;
using DevFlash.Mocking.Tests.Mocking.DateAndTime;
using DevFlash.Mocking.Tests.Mocking.IO;
using DevFlash.Mocking.Tests.Mocking.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFlash.Mocking.Tests.Tests
{
    [TestClass]
    public class EventOccurrencesTests
    {
        private MockDateTimeProvider DateTimeProvider
        {
            get { return new MockDateTimeProvider(new DateTime(2015, 5, 14)); }
        }

        private MockConfigProvider ConfigProvider
        {
            get { return new MockConfigProvider(); }
        }

        private MockPathWrapper PathWrapper
        {
            get { return new MockPathWrapper(); }
        }

        [TestMethod]
        public void DeletesLogFileIfItAlreadyExists()
        {
            const bool FileAlreadyExists = true;

            var productRepository = GetEmptyProductRepository();
            var eventLogger = new EventLogger();

            var fileWrapper = new MockFileWrapperWithEventLog(eventLogger);
            fileWrapper.SetExistsToReturn(FileAlreadyExists);

            var testableClass = new TestableClass(productRepository, DateTimeProvider, ConfigProvider, fileWrapper,
                PathWrapper);

            testableClass.SaveProductsLog();

            var eventLogAssertions = new EventLogAssertions(eventLogger);
            eventLogAssertions.Occurred(Enums.EventType.FileDelete);
        }

        private MockProductRepository GetEmptyProductRepository()
        {
            var products = new List<Product>();
            var productRepository = new MockProductRepository(products);

            return productRepository;
        }

        [TestMethod]
        public void DoesNotDeleteLogFileIfItDoesNotExist()
        {
            const bool FileAlreadyExists = false;

            var productRepository = GetEmptyProductRepository();
            var eventLogger = new EventLogger();

            var fileWrapper = new MockFileWrapperWithEventLog(eventLogger);
            fileWrapper.SetExistsToReturn(FileAlreadyExists);

            var testableClass = new TestableClass(productRepository, DateTimeProvider, ConfigProvider, fileWrapper,
                PathWrapper);

            testableClass.SaveProductsLog();

            var eventLogAssertions = new EventLogAssertions(eventLogger);
            eventLogAssertions.DidNotOccur(Enums.EventType.FileDelete);
        }

        [TestMethod]
        public void DeletesExistingLogBeforeCreatingNewOne()
        {
            const bool FileAlreadyExists = true;

            var productRepository = GetEmptyProductRepository();
            var eventLogger = new EventLogger();

            var fileWrapper = new MockFileWrapperWithEventLog(eventLogger);
            fileWrapper.SetExistsToReturn(FileAlreadyExists);

            var testableClass = new TestableClass(productRepository, DateTimeProvider, ConfigProvider, fileWrapper,
                PathWrapper);

            testableClass.SaveProductsLog();

            var eventLogAssertions = new EventLogAssertions(eventLogger);
            eventLogAssertions.EventHappenedBefore(Enums.EventType.FileDelete, Enums.EventType.FileCreate);
        }

        [TestMethod]
        public void DeletesAndCreatesLogFileWithTheSamePath()
        {
            const string ExpectedLogPath = "OutputFolderPath\\products_14-05-2015_00000.txt";
            const bool FileAlreadyExists = true;

            var productRepository = GetEmptyProductRepository();
            var eventLogger = new EventLogger();

            var fileWrapper = new MockFileWrapperWithEventLog(eventLogger);
            fileWrapper.SetExistsToReturn(FileAlreadyExists);

            var testableClass = new TestableClass(productRepository, DateTimeProvider, ConfigProvider, fileWrapper,
                PathWrapper);

            testableClass.SaveProductsLog();

            var eventLogAssertions = new EventLogAssertions(eventLogger);
            eventLogAssertions.Occurred(Enums.EventType.FileDelete, ExpectedLogPath);
            eventLogAssertions.Occurred(Enums.EventType.FileCreate, ExpectedLogPath);
        }

        [TestMethod]
        public void CreatesLogFileBeforeWritingToIt()
        {
            var productRepository = GetProductRepository(3);
            var eventLogger = new EventLogger();

            var fileWrapper = new MockFileWrapperWithEventLog(eventLogger);

            var testableClass = new TestableClass(productRepository, DateTimeProvider, ConfigProvider, fileWrapper,
                PathWrapper);

            testableClass.SaveProductsLog();

            var eventLogAssertions = new EventLogAssertions(eventLogger);
            eventLogAssertions.EventHappenedBefore(Enums.EventType.FileCreate, Enums.EventType.FileWrite);
        }

        private MockProductRepository GetProductRepository(int productCount)
        {
            var products = new List<Product>();

            for (var i = 0; i < productCount; i++)
            {
                var product = GetProduct(i);
                products.Add(product);
            }

            return new MockProductRepository(products);
        }

        private Product GetProduct(int id)
        {
            return new Product
            {
                Name = "Product " + id,
                Price = id,
                DateAdded = DateTime.Now
            };
        }

        [TestMethod]
        public void WritesMultipleLogLinesForMultipleProducts()
        {
            const int ProductCount = 3;
            const int ExpectedLogFileLines = ProductCount;

            var productRepository = GetProductRepository(ProductCount);
            var eventLogger = new EventLogger();

            var fileWrapper = new MockFileWrapperWithEventLog(eventLogger);

            var testableClass = new TestableClass(productRepository, DateTimeProvider, ConfigProvider, fileWrapper,
                PathWrapper);

            testableClass.SaveProductsLog();

            var eventLogAssertions = new EventLogAssertions(eventLogger);
            eventLogAssertions.OccurredTimes(Enums.EventType.FileWrite, ExpectedLogFileLines);
        }
    }
}
