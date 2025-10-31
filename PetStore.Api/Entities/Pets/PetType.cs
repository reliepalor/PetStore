using System;

namespace PetStore.Api.Entities.Pets;

public class PetType
{
  public int Id { get; set; }

  public required string Name { get; set; }
}
