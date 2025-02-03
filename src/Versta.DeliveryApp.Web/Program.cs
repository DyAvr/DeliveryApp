using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Versta.DeliveryApp.Application;
using Versta.DeliveryApp.Application.Validators;
using Versta.DeliveryApp.Infrastructure;
using Versta.DeliveryApp.Infrastructure.Data;
using Versta.DeliveryApp.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderDtoValidator>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

Migrate(app);

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();
return;

void Migrate(IHost webApplication)
{
    using var scope = webApplication.Services.CreateScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}