using System.Linq;
using DevFlash.Mocking.Model;

namespace DevFlash.Mocking.Repository
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
    }
}
