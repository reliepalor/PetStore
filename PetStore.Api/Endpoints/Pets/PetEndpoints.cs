using System;
using PetStore.Api.Dtos;

namespace PetStore.Api.Endpoints.Pets;

public static class PetEndpoints
{
    const string GetPetEndPointName = "GetPet";
    private static readonly List<PetDto> pets = [
        new(1, "ChuChi", "Cat", 1.11M, new DateOnly(2025, 10, 03)),
        new(2, "ChuChu", "Cat", 2.22M, new DateOnly(2025, 10, 03))
    ];

    public static object MapPetEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("pets")
                    .WithParameterValidation();
        // GET /pets
        group.MapGet("/", () => pets);

        // GET /pets/{id}
        group.MapGet("/{id}", (int id) =>
        {
            PetDto? pet = pets.Find(pet => pet.Id == id);

            return pet is null ? Results.NotFound() : Results.Ok(pet);
        })
            .WithName(GetPetEndPointName);

        // POST /pets   
        group.MapPost("/", (CreatePetDto newPet) =>
        {
          
            PetDto pet = new(
                pets.Count + 1,
                newPet.Name,
                newPet.PetType,
                newPet.Price,
                newPet.BirthDate
            );

            pets.Add(pet);

            return Results.CreatedAtRoute(GetPetEndPointName, new { id = pet.Id }, pet);
        }).WithParameterValidation();
        //PUT /pets
        group.MapPut("/{id}", (int id, UpdatePetDto updatedPet) =>
        {
            var index = pets.FindIndex(pet => pet.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            pets[index] = new PetDto(
                id,
                updatedPet.Name,
                updatedPet.PetType,
                updatedPet.Price,
                updatedPet.BirthDate
            );
            return Results.NoContent();
        }).WithParameterValidation();
        //DELETE /pets/1
        group.MapDelete("/{id}", (int id) =>
        {
            pets.RemoveAll(pets => pets.Id == id);
            return Results.NoContent();
        });

        return group;
    }
}
