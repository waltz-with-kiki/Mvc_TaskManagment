using Microsoft.EntityFrameworkCore;
using NewProject.DAL;
using NewProject.DAL.Interfaces;
using NewProject.DAL.Repositories;
using NewProject.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MonadaMech>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MonadaMech")));

builder.Services.AddTransient<IRepository<User>, DbRepository<User>>();
builder.Services.AddTransient<IRepository<Project>, ProjectDbRepository>();
builder.Services.AddTransient<IRepository<Exercise>, DbRepository<Exercise>>();
builder.Services.AddTransient<IRepository<UserProject>, DbRepository<UserProject>>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{

    //MonadaMech content = serviceScope.ServiceProvider.GetService<MonadaMech>();
    var dbContext = serviceScope.ServiceProvider.GetService<MonadaMech>();
    dbContext.Database.Migrate();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern:  "{controller=Main}/{action=Index}/{id?}"
    );

app.Run();
