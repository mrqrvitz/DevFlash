using DevFlash.Mocking.Repository;
using DevFlash.Mocking.TestableCode;
using DevFlash.Mocking.TestableCode.ConfigProvider;
using DevFlash.Mocking.TestableCode.DateTimeProvider;
using DevFlash.Mocking.TestableCode.IO;

namespace DevFlash.Mocking
{
    public class Main
    {
        private readonly DateTimeProvider dateTimeProvider = new DateTimeProvider();
        private readonly ConfigProvider configProvider = new ConfigProvider();
        private readonly FileWrapper fileWrapper = new FileWrapper();
        private readonly PathWrapper pathWrapper = new PathWrapper();

        private readonly ProductRepository productRepository = new ProductRepository();

        public void SaveProductLog()
        {
            var untestable = new UntestableClass(productRepository);
            untestable.SaveProductsLog();

            var testable = new TestableClass(productRepository, dateTimeProvider, configProvider, fileWrapper,
                pathWrapper);

            testable.SaveProductsLog();
        }
    }
}
