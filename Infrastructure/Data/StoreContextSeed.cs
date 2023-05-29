using System.Text.Json;
using Core.Entities;
using Infrastruture.Data;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.ProductBrands.Any())
            {
                // read the brans data 
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                // serialized the data from json file
                var brans = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                // add the data to database => ProductBrands table
                context.ProductBrands.AddRange(brans);
            }
        
            if(!context.ProductTypes.Any())
            {
                // read the types data 
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                // serialized the data from json file
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                // add the data to database => ProductTypes table
                context.ProductTypes.AddRange(types);
            }
            if(!context.Products.Any())
            {
                // read the Product data 
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                // serialized the data from json file
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                // add the data to database => Products table
                context.Products.AddRange(products);
            }

            // if there is changes in memory then save them in database
            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}