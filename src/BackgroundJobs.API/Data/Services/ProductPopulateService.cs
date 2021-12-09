using BackgroundJobs.API.Data.Entities;
using BackgroundJobs.API.Data.Enums;

namespace BackgroundJobs.API.Data.Service
{
    public class ProductPopulateService
    {
        private readonly CatalogDbContext _context;

        public ProductPopulateService(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            if (_context.Database.EnsureCreated())
            {
                _context.Products.Add(new ProductModel()
                {
                    Title = "Sandalia",
                    Description = "Sandalia Preta Couro Salto Fino",
                    Price = 249.50,
                    Quantity = 100
                });

                _context.Products.Add(new ProductModel()
                {
                    Title = "Sapatilha",
                    Description = "Sapatilha Tecido Platino",
                    Price = 142.50,
                    Quantity = 25,
                    Status = EntityStatusEnum.Inactive
                });

                _context.Products.Add(new ProductModel()
                {
                    Title = "Chinelo",
                    Description = "Chinelo Tradicional AdultoUnissex",
                    Price = 60.50,
                    Quantity = 50
                });

                _context.Products.Add(new ProductModel()
                {
                    Title = "Tênis",
                    Description = "Chinelo Tradicional AdultoUnissex",
                    Price = 60.50,
                    Quantity = 50,
                    Status = EntityStatusEnum.Inactive
                });

                _context.SaveChanges();
            };
        }

    }
}