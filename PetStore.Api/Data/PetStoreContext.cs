using System;
using Microsoft.EntityFrameworkCore;
using PetStore.Api.Entities.Pets;
namespace PetStore.Api.Data;

public class PetStoreContext(DbContextOptions<PetStoreContext> options) 
    : DbContext(options)
{
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<PetType> Types => Set<PetType>();
  
}

