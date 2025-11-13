using System;
using Microsoft.EntityFrameworkCore;
using PetStore.Api.Entities.Foods;
namespace PetStore.Api.Data;

public class FoodStoreContext(DbContextOptions<FoodStoreContext> options) 
    : DbContext(options)
{
   public DbSet<Food> Foods => Set<Food>();
    public DbSet<FoodType> FoodTypes => Set<FoodType>();
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<FoodType>().HasData(
            new { Id = 1, Name = "Meat" },
            new { Id = 2, Name = "Fish" },
            new { Id = 3, Name = "Snack" },
            new { Id = 4, Name = "Drink" }
        );

        modelBuilder.Entity<Food>().HasData(
        new { Id = 1, Name = "Beef Biscuits", FoodTypeId = 1, Price = 10.50m },
        new { Id = 2, Name = "Chicken Nuggets", FoodTypeId = 1, Price = 8.75m },
        new { Id = 3, Name = "Thin Tuna Cuts", FoodTypeId = 2, Price = 5.25m },
        new { Id = 4, Name = "Apple Crunch", FoodTypeId = 3, Price = 6.00m },
        new { Id = 5, Name = "Goat Milk", FoodTypeId = 4, Price = 12.99m },
        new { Id = 6, Name = "Fish Jerky", FoodTypeId = 2, Price = 9.40m }    
        );

         
    }
}
