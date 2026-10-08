using FairEquity.Features;
using FairEquity.Infrastructure;
using FairEquity.Infrastructure.Persistence;
using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddInfrastructure();

builder.Services.AddFeatures();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi(options =>
{
    // Slices nest their contracts (CreateCompany.Request), so prefix schema ids with the slice name.
    options.CreateSchemaReferenceId = type =>
        type.Type is { IsNested: true, DeclaringType: { } slice }
            ? $"{slice.Name}{type.Type.Name}"
            : OpenApiOptions.CreateDefaultSchemaReferenceId(type);
});

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    await app.ApplyMigrationsAsync();
}

app.MapDefaultEndpoints();
app.MapFeatures();

app.Run();
