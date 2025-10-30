namespace PetStore.Api.Dtos;

public record class FoodDto
(
    int Id,
    string FoodName,
    string FoodType,
    decimal FoodPrice
);

