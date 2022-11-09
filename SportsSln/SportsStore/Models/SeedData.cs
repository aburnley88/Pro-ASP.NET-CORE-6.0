using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any()) { context.Database.Migrate();


                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            ProductName = "Kayak",
                            ProductDescription = "A single person boat",
                            ProductCategory = "Watersports",
                            ProductPrice = 275
                        },
                        new Product
                        {
                            ProductName = "Lifejacket",
                            ProductDescription = "A floatation device",
                            ProductCategory = "Watersports",
                            ProductPrice = 48.95M
                        },
                        new Product
                        {
                            ProductName = "Soccer Ball",
                            ProductDescription = "FIFA approved ball",
                            ProductCategory = "soccer",
                            ProductPrice = 19.50m
                        },
                        new Product
                        {
                            ProductName = "Corner Flags",
                            ProductDescription = "Flags for the field",
                            ProductCategory = "soccer",
                            ProductPrice = 34.95m
                        },
                        new Product
                        {
                            ProductName = "Stadium",
                            ProductDescription = "Literally a stadium",
                            ProductCategory = "soccer",
                            ProductPrice = 79500
                        },
                        new Product
                        {
                            ProductName = "Thinking Cap",
                            ProductDescription = "Cap. It's just a helmet",
                            ProductCategory = "Chess",
                            ProductPrice = 16
                        },
                        new Product
                        {
                            ProductName = "Unsteady Chair",
                            ProductDescription = "Bigger they are harder they fall",
                            ProductCategory = "Chess",
                            ProductPrice = 29.95m
                        },
                        new Product
                        {
                            ProductName = "Human Chess Board",
                            ProductDescription = "Play with the gang",
                            ProductCategory = "Chess",
                            ProductPrice = 75
                        },
                        new Product
                        {
                            ProductName = "Bling-Bling King",
                            ProductDescription = "Cringe. Embarassing AF!",
                            ProductCategory = "Chess",
                            ProductPrice = 1200
                        }
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
