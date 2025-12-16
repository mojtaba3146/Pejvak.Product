using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<EFDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PejvakProductConnectionString")));

builder.Services.Scan(_ =>
              _.FromAssembliesOf(
                   typeof(IScope),
                   typeof(EFDataContext))
               .AddClasses(_ => _.AssignableTo<IScope>()).AsImplementedInterfaces()
              .WithScopedLifetime());

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
