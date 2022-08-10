using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProduct.Api.Models.Configuaration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
			builder.HasData
			(
				//Mugs
				new Product
				{
					Id = 1,
					Name = "Travel Mug",
					Description = "Code Maze",
					Price = 11
				},
				new Product
				{
					Id = 2,
					Name = "Classic Mug",
					Description = "Code Maze",
					Price = 22
				},
				//Clothing
				new Product
				{
					Id = 3,
					Name = "Code Maze Logo T-Shirt",
					Description = "Code Maze",
					Price = 20
				},
				new Product
				{
					Id = 4,
					Name = "Pullover Hoodie",
					Description = "Code Maze",
					Price = 30
				}
				
			);
		}
    }
}
