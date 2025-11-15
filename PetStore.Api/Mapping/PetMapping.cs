using System;
using PetStore.Api.Dtos;
using PetStore.Api.Entities.Pets;

namespace PetStore.Api.Mapping;

public static class PetMapping
{
    public static Pet ToEntity(this CreatePetDto pet)
    {
        return new Pet()
        {
            Name = pet.Name,
            PetTypeId = pet.PetTypeId,           
            Price = pet.Price,
            BirthDate = pet.BirthDate
        };           
    }

    public static PetDto ToDto(this Pet pet)
    {
            return new (
                pet.Id,
                pet.Name,
                pet.Type!.Name,
                pet.Price,
                pet.BirthDate
            );        
    }
}
