using System;
using System.Collections.Generic;

using DevFlash.AAA.Dto;
using DevFlash.AAA.Implementations;
using DevFlash.AAA.Tests.Stubs;

namespace DevFlash.AAA.Tests
{
    public class ProductFileLoggerTestsFixtureBuilder
    {
        public const int DefaultProductId = 123;
        public const string DefaultProductName = "ProductName";
        public const decimal DefaultProductPrice = 123m;

        public readonly DateTime CurrentDateTime = new DateTime(2016, 7, 12, 5, 6, 33);

        private bool builderFileExists;
        private int builderProductsCount;

        public StubDateTimeProvider DateTimeProvider { get; private set; }
        public StubFileAccessor FileAccessor { get; private set; }
        public StubProductService ProductService { get; private set; }

        public int ProductId
        {
            get { return DefaultProductId; }
        }

        public string ProductName
        {
            get { return DefaultProductName; }
        }

        public decimal ProductPrice
        {
            get { return DefaultProductPrice; }
        }

        private ProductFileLoggerTestsFixtureBuilder()
        {
        }

        public static ProductFileLoggerTestsFixtureBuilder Define()
        {
            return new ProductFileLoggerTestsFixtureBuilder();
        }

        public ProductFileLoggerTestsFixtureBuilder WithAlreadyExistingFile()
        {
            this.builderFileExists = true;
            return this;
        }

        public ProductFileLoggerTestsFixtureBuilder WithProductsCount(int count)
        {
            this.builderProductsCount = count;
            return this;
        }

        public ProductFileLogger Build()
        {
            this.DateTimeProvider = new StubDateTimeProvider(this.CurrentDateTime);

            this.FileAccessor = GetFileAccessor();
            this.ProductService = GetProductService();

            var logger = new ProductFileLogger(this.DateTimeProvider, this.FileAccessor, this.ProductService);

            return logger;
        }

        private StubFileAccessor GetFileAccessor()
        {
            var fileAccessor = new StubFileAccessor();
            fileAccessor.ExistsResult = this.builderFileExists;

            return fileAccessor;
        }

        private StubProductService GetProductService()
        {
            var productService = new StubProductService();

            var products = new List<Product>();

            for (var i = 0; i < this.builderProductsCount; i++)
            {
                var product = new Product
                {
                    Id = DefaultProductId,
                    Name = DefaultProductName,
                    Price = DefaultProductPrice
                };

                products.Add(product);
            }

            productService.GetAllResult = products;
            return productService;
        }
    }
}
