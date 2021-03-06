﻿using System.Collections.Generic;
using System.Linq;
using DevFlash.Mocking.Model;
using DevFlash.Mocking.Repository;
using DevFlash.Mocking.TestableCode.Config;
using DevFlash.Mocking.TestableCode.DateAndTime;
using DevFlash.Mocking.TestableCode.IO;

namespace DevFlash.Mocking.TestableCode
{
    public class TestableClassUsingDateTimeWrapper
    {
        private readonly IProductRepository productRepository;

        private readonly IConfigProvider configProvider;
        private readonly IFileWrapper fileWrapper;
        private readonly IPathWrapper pathWrapper;

        public TestableClassUsingDateTimeWrapper(IProductRepository productRepository, IConfigProvider configProvider,
            IFileWrapper fileWrapper, IPathWrapper pathWrapper)
        {
            this.productRepository = productRepository;
            this.configProvider = configProvider;
            this.fileWrapper = fileWrapper;
            this.pathWrapper = pathWrapper;
        }

        public void SaveProductsLog()
        {
            var productsAddedSinceYesterday = GetProductsAddedSinceYesterday();

            var logFilePath = GetLogFilePath();

            if (fileWrapper.Exists(logFilePath))
            {
                fileWrapper.Delete(logFilePath);
            }

            using (var logStreamWriter = fileWrapper.CreateToRead(logFilePath))
            {
                foreach (var product in productsAddedSinceYesterday)
                {
                    var productLogLine = string.Format("{0}\t{1}\t\t\t{2}", product.Name, product.Price.ToString("C"),
                        product.DateAdded);

                    logStreamWriter.WriteLine(productLogLine);
                }
            }
        }

        private string GetLogFilePath()
        {
            var logFileName = GetLogFileName();

            var outputFolderPath = configProvider.OutputFolderPath;
            var logFilePath = pathWrapper.Combine(outputFolderPath, logFileName);

            return logFilePath;
        }

        private string GetLogFileName()
        {
            //14-05-2016_225913
            var timeStamp = DateTimeWrapper.Now.ToString("dd-MM-yyyy_Hmmss");

            return string.Format("products_{0}.txt", timeStamp);
        }

        private IEnumerable<Product> GetProductsAddedSinceYesterday()
        {
            var today = DateTimeWrapper.Now.Date;
            var yesterday = today.AddDays(-1);

            return productRepository.GetAll().Where(x => x.DateAdded >= yesterday);
        }
    }
}
