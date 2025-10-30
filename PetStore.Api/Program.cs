using PetStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//---------------------PETS-------------------
const string GetPetEndPointName = "GetPet";
List<PetDto> pets = [
    new(1, "ChuChi", "Cat", 1.11M, new DateOnly(2025, 10, 03)),
    new(2, "ChuChu", "Cat", 2.22M, new DateOnly(2025, 10, 03))
];

// GET /pets
app.MapGet("/pets", () => pets);

// GET /pets/{id}
app.MapGet("/pets/{id}", (int id) => pets.Find(pet => pet.Id == id))
    .WithName(GetPetEndPointName);

// POST /pets
app.MapPost("/pets", (CreatePetDto newPet) =>
{
    PetDto pet = new(
        pets.Count + 1,
        newPet.Name,
        newPet.Type,
        newPet.Price,
        newPet.BirthDate
    );

    pets.Add(pet);

    return Results.CreatedAtRoute(GetPetEndPointName, new { id = pet.Id }, pet);
});
//PUT /pets
app.MapPut("pets/{id}", (int id, UpdatePetDto updatedPet) =>
{
    var index = pets.FindIndex(pet => pet.Id == id);

    pets[index] = new PetDto(
        id,
        updatedPet.Name,
        updatedPet.Type,
        updatedPet.Price,
        updatedPet.BirthDate
    );
    return Results.NoContent();
});
//DELETE /pets/1
app.MapDelete("pets/{id}", (int id) =>
{
    pets.RemoveAll(pets => pets.Id == id);
    return Results.NoContent();
});
//---------------------FOODS-------------------
const string GetFoodEndPointName = "GetFood";
List<FoodDto> foods = [
    new(1, "Beef Biscuits", "Meat", 10.11M),
    new(2, "Goat Milk", "Drinks", 15.11M)
];

// GET /foods
app.MapGet("/foods", () => foods);

// GET /foods/{id}
app.MapGet("/foods/{id}", (int id) => foods.Find(food => food.Id == id))
    .WithName(GetFoodEndPointName);

// POST /foods
app.MapPost("/foods", (CreateFoodDto newFood) =>
{
    FoodDto food = new(
        foods.Count + 1,
        newFood.FoodName,
        newFood.FoodType,
        newFood.FoodPrice
    );

    foods.Add(food);

    return Results.CreatedAtRoute(GetFoodEndPointName, new { id = food.Id }, food);
});
//PUT /foods
app.MapPut("foods/{id}", (int id, UpdateFoodDto updatedFood) =>
{
    var index = foods.FindIndex(food => food.Id == id);

    foods[index] = new FoodDto(
        id,
        updatedFood.FoodName,
        updatedFood.FoodType,
        updatedFood.FoodPrice
    );
    return Results.NoContent();
});
//DELETE /foods/1
app.MapDelete("foods/{id}", (int id) =>
{
    foods.RemoveAll(foods => foods.Id == id);
    return Results.NoContent();
});
app.Run();
