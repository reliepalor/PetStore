using System;

namespace PetStore.Api.Entities.Foods;

public class Food
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int FoodTypeId { get; set; }
    public FoodType? Type { get; set; }
    public decimal Price { get; set; }

}
