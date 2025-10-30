namespace PetStore.Api.Dtos;

public record class CreatePetDto(
    string Name,
    string Type,
    decimal Price,
    DateOnly BirthDate
);