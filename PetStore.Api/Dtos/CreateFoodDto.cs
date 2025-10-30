namespace PetStore.Api.Dtos;

public record class CreateFoodDto(
    string FoodName,
    string FoodType,
    decimal FoodPrice
);