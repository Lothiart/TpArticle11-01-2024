using Repositories;
using Repositories.Contracts;
using Business;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);






// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(


    o => { o.UseSqlServer(builder.Configuration.GetConnectionString("TpWikY")); });



builder.Services.AddScoped<IArticleBusiness, ArticleBusiness>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommentaireBusiness, CommentaireBusiness>();
builder.Services.AddScoped<ICommentaireRepository, CommentaireRepository>();
var app = builder.Build();

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
