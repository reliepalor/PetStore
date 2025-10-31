using Microsoft.EntityFrameworkCore;
using PetStore.Api.Data;
using PetStore.Api.Endpoints.Foods;
using PetStore.Api.Endpoints.Pets;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("PetStore");
builder.Services.AddSqlite<PetStoreContext>(connString);
builder.Services.AddSqlite<FoodStoreContext>(connString);

var app = builder.Build();


app.MapPetEndpoints();
app.MapFoodEndpoints();

app.Run();
