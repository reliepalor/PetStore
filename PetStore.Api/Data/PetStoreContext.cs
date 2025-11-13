using System;
using Microsoft.EntityFrameworkCore;
using PetStore.Api.Entities.Pets;
namespace PetStore.Api.Data;

public class PetStoreContext(DbContextOptions<PetStoreContext> options) 
    : DbContext(options)
{
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<PetType> Types => Set<PetType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PetType>().HasData(
            new { Id = 1, Name = "Dog" },
            new { Id = 2, Name = "Cat" }
        );
        
        modelBuilder.Entity<Pet>().HasData(
            new { Id = 1, Name = "Chuchi", PetTypeId = 2, Price = 200.50m, BirthDate = new DateOnly(2024, 10, 1) },
            new { Id = 2, Name = "Chuchu", PetTypeId = 2, Price = 180.75m, BirthDate = new DateOnly(2024, 9, 15) },
            new { Id = 3, Name = "Vuevue", PetTypeId = 2, Price = 350.00m, BirthDate = new DateOnly(2023, 11, 5) },
            new { Id = 4, Name = "Ungang", PetTypeId = 2, Price = 90.00m, BirthDate = new DateOnly(2025, 1, 20) },
            new { Id = 5, Name = "Jaya", PetTypeId = 1, Price = 215.25m, BirthDate = new DateOnly(2024, 12, 30) },
            new { Id = 6, Name = "Trisha", PetTypeId = 1, Price = 120.10m, BirthDate = new DateOnly(2023, 8, 10) }
        );
    }
}

