using System.ComponentModel.DataAnnotations;

namespace PetStore.Api.Dtos;

public record class UpdatePetDto
(
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string PetType,
    [Range(1, 10000)]decimal Price,
    DateOnly BirthDate
);