namespace PetStore.Api.Dtos;

public record class UpdatePetDto
(
    string Name,
    string Type,
    decimal Price,
    DateOnly BirthDate
);