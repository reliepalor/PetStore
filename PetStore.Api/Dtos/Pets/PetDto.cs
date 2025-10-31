namespace PetStore.Api.Dtos;

public record class PetDto(
    int Id,
    string Name,
    string PetType,
    decimal Price,
    DateOnly BirthDate
);
