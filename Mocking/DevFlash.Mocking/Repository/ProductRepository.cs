using System;
using System.Collections.Generic;
using System.Linq;
using DevFlash.Mocking.Model;

namespace DevFlash.Mocking.Repository
{
    internal class ProductRepository : IProductRepository
    {
        public IQueryable<Product> GetAll()
        {
            var productList = new List<Product> {GetProduct(1), GetProduct(2), GetProduct(3)};

            return productList.AsQueryable();
        }

        private Product GetProduct(int id)
        {
            return new Product
            {
                Name = string.Format("Product_{0}", id),
                DateAdded = DateTime.Now.AddDays(-id),
                Price = id
            };
        }
    }
}
