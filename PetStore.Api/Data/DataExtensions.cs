using System;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
        dbContext.Database.Migrate();
    }
}
