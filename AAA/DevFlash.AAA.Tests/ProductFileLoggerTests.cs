using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFlash.AAA.Tests
{
    [TestClass]
    public class ProductFileLoggerTests
    {
        private ProductFileLoggerTestsFixtureBuilder fixtureBuilder;

        private ProductFileLoggerTestAssertions Assertions
        {
            get
            {
                return new ProductFileLoggerTestAssertions(fixtureBuilder);
            }
        }

        [TestInitialize]
        public void SetUp()
        {
            this.fixtureBuilder = null;
        }

        private void Act()
        {
            if (this.fixtureBuilder == null)
            {
                throw new Exception("Fixture Builder was not set");
            }

            var productLogger = this.fixtureBuilder.Build();
            productLogger.SaveProductLog();
        }

        [TestMethod]
        public void DoesNotCreateFile_WhenAlreadyExists()
        {
            this.fixtureBuilder = ProductFileLoggerTestsFixtureBuilder.Define().WithAlreadyExistingFile();

            Act();

            Assertions.DidNotCreateFile();
        }

        [TestMethod]
        public void CreatesFile_WhenDoesNotExist()
        {
            this.fixtureBuilder = ProductFileLoggerTestsFixtureBuilder.Define();

            Act();

            Assertions.CreatedFile();
        }

        [TestMethod]
        public void ClosesFile_WhenDoesNotExist()
        {
            this.fixtureBuilder = ProductFileLoggerTestsFixtureBuilder.Define();

            Act();

            Assertions.ClosedFile();
        }

        [TestMethod]
        public void DoesNotCloseFile_WhenFileAlreadyExist()
        {
            this.fixtureBuilder = ProductFileLoggerTestsFixtureBuilder.Define().WithAlreadyExistingFile();

            Act();

            Assertions.DidNotCloseFile();
        }

        [TestMethod]
        public void SetsCurrentDateToFileName()
        {
            this.fixtureBuilder = ProductFileLoggerTestsFixtureBuilder.Define();

            Act();

            Assertions.SetCurrentDateToFileName();
        }

        [TestMethod]
        public void WritesEmptyFile_WhenNoProductsReturned()
        {
            this.fixtureBuilder = ProductFileLoggerTestsFixtureBuilder.Define().WithProductsCount(0);

            Act();

            Assertions.WroteEmptyFile();
        }

        [TestMethod]
        public void WritesThreeProducts_WhenThreeProductsReturned()
        {
            this.fixtureBuilder = ProductFileLoggerTestsFixtureBuilder.Define().WithProductsCount(3);

            Act();

            Assertions.WroteThreeProductsToFile();
        }
    }
}
