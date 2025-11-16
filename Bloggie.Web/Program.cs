using Bloggie.Web.Data;
using Bloggie.Web.Repo;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllersWithViews();



// Use CORS before MapControllers


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BloggieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BloggieDbConnectionString")));

builder.Services.AddScoped<ITagRepo, TagRepo>();
builder.Services.AddScoped<IBlogPostRepo, BlogPostRepo>();

var app = builder.Build();
app.UseCors("AllowReactApp");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
