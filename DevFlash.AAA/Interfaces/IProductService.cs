using System.Collections.Generic;

using DevFlash.AAA.Dto;

namespace DevFlash.AAA.Interfaces
{
    public interface IProductService
    {
        Product Get(int id);

        List<Product> GetAll();
    }
}
