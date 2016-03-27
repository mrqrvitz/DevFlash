using System.Collections.Generic;

using DevFlash.AAA.Dto;
using DevFlash.AAA.Interfaces;

namespace DevFlash.AAA.Tests.Stubs
{
    public class StubProductService : IProductService
    {
        public List<Product> GetAllResult { get; set; }

        public Product GetResult { get; set; }

        public Product Get(int id)
        {
            return this.GetResult;
        }

        public List<Product> GetAll()
        {
            return this.GetAllResult;
        }
    }
}
