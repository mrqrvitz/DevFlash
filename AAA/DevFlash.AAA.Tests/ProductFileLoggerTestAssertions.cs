using DevFlash.AAA.Tests.Stubs;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFlash.AAA.Tests
{
    public class ProductFileLoggerTestAssertions
    {
        private readonly ProductFileLoggerTestsFixtureBuilder fixtureBuilder;

        private StubDateTimeProvider DateTimeProvider
        {
            get { return this.fixtureBuilder.DateTimeProvider; }
        }

        private StubFileAccessor FileAccessor
        {
            get { return this.fixtureBuilder.FileAccessor; }
        }

        private StubProductService ProductService
        {
            get { return this.fixtureBuilder.ProductService; }
        }

        public ProductFileLoggerTestAssertions(ProductFileLoggerTestsFixtureBuilder fixtureBuilder)
        {
            this.fixtureBuilder = fixtureBuilder;
        }

        public void DidNotCreateFile()
        {
            Assert.IsFalse(this.FileAccessor.CreatedFile);
        }

        public void CreatedFile()
        {
            Assert.IsTrue(this.FileAccessor.CreatedFile);
        }

        public void ClosedFile()
        {
            Assert.IsTrue(this.FileAccessor.ClosedFile);
        }

        public void DidNotCloseFile()
        {
            Assert.IsFalse(this.FileAccessor.ClosedFile);
        }

        public void SetCurrentDateToFileName()
        {
            var expectedDateTime = this.DateTimeProvider.CurrentTime;
            var createdFilePath = this.FileAccessor.CreatedFilePath;

            var expectedYearText = expectedDateTime.Year.ToString();
            var expectedMonthText = expectedDateTime.Month.ToString();
            var expectedDayText = expectedDateTime.Day.ToString();

            Assert.IsTrue(createdFilePath.Contains(expectedYearText));
            Assert.IsTrue(createdFilePath.Contains(expectedMonthText));
            Assert.IsTrue(createdFilePath.Contains(expectedDayText));
        }

        public void WroteEmptyFile()
        {
            var textsWrittenToFile = this.FileAccessor.TextsWrittenToFile;
            Assert.AreEqual(0, textsWrittenToFile.Count);
        }

        public void WroteThreeProductsToFile()
        {
            var textsWrittenToFile = this.FileAccessor.TextsWrittenToFile;

            Assert.AreEqual(3, textsWrittenToFile.Count);

            AssertWroteProductToFile(textsWrittenToFile[0]);
            AssertWroteProductToFile(textsWrittenToFile[1]);
            AssertWroteProductToFile(textsWrittenToFile[2]);
        }

        private void AssertWroteProductToFile(string writtenText)
        {
            var expectedIdText = this.fixtureBuilder.ProductId.ToString();
            var expectedName = this.fixtureBuilder.ProductName;
            var expectedPriceText = this.fixtureBuilder.ProductPrice.ToString();

            Assert.IsTrue(writtenText.Contains(expectedIdText));
            Assert.IsTrue(writtenText.Contains(expectedName));
            Assert.IsTrue(writtenText.Contains(expectedPriceText));
        }
    }
}
