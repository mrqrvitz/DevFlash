using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DevFlash.Mocking.Model;
using DevFlash.Mocking.Repository;

namespace DevFlash.Mocking
{
    public class UntestableClass
    {
        private readonly IProductRepository productRepository;

        public UntestableClass(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void SaveProductsLog()
        {
            var productsAddedSinceYesterday = GetProductsAddedSinceYesterday();

            var logFilePath = GetLogFilePath();

            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }

            using (var logFileStream = File.Create(logFilePath))
            using (var logStreamWriter = new StreamWriter(logFileStream))
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

            var outputFolderPath = ConfigurationManager.AppSettings["OutputFolderPath"];
            var logFilePath = Path.Combine(outputFolderPath, logFileName);

            return logFilePath;
        }

        private string GetLogFileName()
        {
            //14-05-2016_225913
            var timeStamp = DateTime.Now.ToString("dd-MM-yyyy_Hmmss");

            return string.Format("products_{0}.txt", timeStamp);
        }

        private IEnumerable<Product> GetProductsAddedSinceYesterday()
        {
            var today = DateTime.Now.Date;
            var yesterday = today.AddDays(-1);

            return productRepository.GetAll().Where(x => x.DateAdded >= yesterday);
        }
    }
}
