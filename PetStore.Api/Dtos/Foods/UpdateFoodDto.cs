namespace PetStore.Api.Dtos;

public record class UpdateFoodDto
(
    string FoodName,
    string FoodType,
    decimal FoodPrice
);