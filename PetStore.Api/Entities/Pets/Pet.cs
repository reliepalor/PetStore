using System;

namespace PetStore.Api.Entities.Pets;

public class Pet
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int PetTypeId { get; set; }

    public PetType? Type { get; set; }

    public decimal Price { get; set; }

    public DateOnly BirthDate { get; set; }
}
