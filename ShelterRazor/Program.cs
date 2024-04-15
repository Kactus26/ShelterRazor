using Microsoft.EntityFrameworkCore;
using ShelterRazor.Services;
using ShelterRazor.Data;
using ShelterRazor.Interfaces;
using ShelterRazor.Repository;
using ShelterRazor.ViewComponents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Seed>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IOwner, OwnerRepository>();
builder.Services.AddScoped<IPet, PetRepository>();
builder.Services.AddScoped<IPetShelter, PetShelterRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<KindsCountViewComponent>();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    await new Seed(scope.ServiceProvider.GetRequiredService<DataContext>()).SeedDataContext();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
