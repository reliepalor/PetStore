using System.ComponentModel.DataAnnotations;

namespace PetStore.Api.Dtos;

public record class CreateFoodDto(
    [Required][StringLength(50)]string FoodName,
    [Required][StringLength(20)]string FoodType,
    [Range(1, 10000)]decimal FoodPrice
);