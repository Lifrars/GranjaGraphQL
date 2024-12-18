using Microsoft.EntityFrameworkCore;
using GranjaGraphQL.Data;
using GranjaGraphQL.GraphSql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()       
    .AddMutationType<Mutation>() 
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.MapGraphQL();
app.Run();