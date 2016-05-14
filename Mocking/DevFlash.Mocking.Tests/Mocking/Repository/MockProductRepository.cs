using System.Collections.Generic;
using System.Linq;
using DevFlash.Mocking.Model;
using DevFlash.Mocking.Repository;

namespace DevFlash.Mocking.Tests.Mocking.Repository
{
    internal class MockProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public MockProductRepository(List<Product> products)
        {
            this.products = products;
        }

        public IQueryable<Product> GetAll()
        {
            return products.AsQueryable();
        }
    }
}
