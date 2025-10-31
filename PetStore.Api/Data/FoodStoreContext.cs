using System;
using Microsoft.EntityFrameworkCore;
using PetStore.Api.Entities.Foods;
namespace PetStore.Api.Data;

public class FoodStoreContext(DbContextOptions<FoodStoreContext> options) 
    : DbContext(options)
{
   public DbSet<Food> Foods => Set<Food>();
   public DbSet<FoodType> Types => Set<FoodType>();
  
}
