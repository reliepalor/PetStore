using System.ComponentModel.DataAnnotations;

namespace PetStore.Api.Dtos;

public record class CreateFoodDto(
    [Required][StringLength(50)]string FoodName,
    int FoodTypeId,
    [Range(1, 10000)]decimal FoodPrice
);