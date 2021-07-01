using APIWhitSwagger.Domain.Entities;
using APIWhitSwagger.Domain.Interfaces;
using APIWithSwagger.Infrastructure.Data;

namespace APIWithSwagger.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
