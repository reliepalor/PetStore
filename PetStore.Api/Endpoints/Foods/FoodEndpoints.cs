using System;
using Microsoft.EntityFrameworkCore;
using PetStore.Api.Dtos;
using PetStore.Api.Data;
using PetStore.Api.Entities.Foods;

namespace PetStore.Api.Endpoints.Foods;

public static class FoodEndpoints
{
    const string GetFoodEndPointName = "GetFood";
    private static readonly List<FoodDto> foods = [
        new(1, "Beef Biscuits", "Meat", 10.11M),
        new(2, "Goat Milk", "Drinks", 15.11M)
    ];

    public static RouteGroupBuilder MapFoodEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("foods");
        // GET /foods
        group.MapGet("/", () => foods);

        // GET /foods/{id}
        group.MapGet("/{id}", (int id) =>
        {
            FoodDto? food = foods.Find(food => food.Id == id);

            return food is null ? Results.NotFound() : Results.Ok(food);
        })
            .WithName(GetFoodEndPointName);

        // POST /foods
        group.MapPost("/", (CreateFoodDto newFood, FoodStoreContext DbContext) =>
        {
            Food food = new()
            {
                Name = newFood.FoodName,
                FoodTypes = DbContext.FoodTypes.Find(newFood.FoodTypeId),
                FoodTypeId = newFood.FoodTypeId,
                Price = newFood.FoodPrice
            };

            DbContext.Foods.Add(food);
            DbContext.SaveChanges();

            return Results.CreatedAtRoute(GetFoodEndPointName, new { id = food.Id }, food);
        }).WithParameterValidation();
        //PUT /foods
        group.MapPut("/{id}", (int id, UpdateFoodDto updatedFood) =>
        {
            var index = foods.FindIndex(food => food.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }
            foods[index] = new FoodDto(
                id,
                updatedFood.FoodName,
                updatedFood.FoodType,
                updatedFood.FoodPrice
            );
            return Results.NoContent();
        });
        //DELETE /foods/1
        group.MapDelete("/{id}", (int id) =>
        {
            foods.RemoveAll(foods => foods.Id == id);
            return Results.NoContent();
        });

        return group;
    }
}
