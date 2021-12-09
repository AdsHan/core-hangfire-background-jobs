using BackgroundJobs.API.Data.Enums;
using BackgroundJobs.API.Data.Repositories;

namespace BackgroundJobs.API.Jobs;

public class DeleteProductsJob : IJob
{

    private readonly IProductRepository _productRepository;

    public DeleteProductsJob(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task DoWork()
    {

        var products = await _productRepository.GetAllAsync();

        foreach (var product in products)
        {
            if (product.Status == EntityStatusEnum.Inactive)
            {
                await _productRepository.RemoveAsync(product);
            }
        }

        await _productRepository.SaveAsync();
    }

}

