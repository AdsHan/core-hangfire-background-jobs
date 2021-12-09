using BackgroundJobs.API.Data.DomainObjects;
using BackgroundJobs.API.Data.Entities;

namespace BackgroundJobs.API.Data.Repositories;

public interface IProductRepository : IRepository<ProductModel>
{
    Task<List<ProductModel>> GetAllAsync();
    Task<ProductModel> GetByIdAsync(Guid id);
    Task AddAsync(ProductModel product);
    Task UpdateAsync(ProductModel product);
    Task RemoveAsync(ProductModel product);
}
