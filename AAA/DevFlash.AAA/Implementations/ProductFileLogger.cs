using DevFlash.AAA.Dto;
using DevFlash.AAA.Interfaces;

namespace DevFlash.AAA.Implementations
{
    public class ProductFileLogger
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IFileAccessor fileAccessor;
        private readonly IProductService productService;
        private string logFileName;

        public ProductFileLogger(IDateTimeProvider dateTimeProvider, IFileAccessor fileAccessor,
            IProductService productService)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.fileAccessor = fileAccessor;
            this.productService = productService;
        }

        public void SaveProductLog()
        {
            var products = productService.GetAll();

            this.logFileName = GetLogFileName();

            if (fileAccessor.Exists(this.logFileName))
            {
                return;
            }

            fileAccessor.CreateFile(this.logFileName);

            foreach (var product in products)
            {
                Log(product);
            }

            fileAccessor.CloseFile(this.logFileName);
        }

        private string GetLogFileName()
        {
            var currentDateTime = dateTimeProvider.Now();
            return currentDateTime.ToShortDateString();
        }

        private void Log(Product product)
        {
            var productLog = string.Format("{0};{1};{2}", product.Id, product.Name, product.Price);
            fileAccessor.WriteToFile(this.logFileName, productLog);
        }
    }
}
