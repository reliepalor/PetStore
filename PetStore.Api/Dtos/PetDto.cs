namespace PetStore.Api.Dtos;

public record class PetDto(
    int Id,
    string Name,
    string Type,
    decimal Price,
    DateOnly BirthDate
);
