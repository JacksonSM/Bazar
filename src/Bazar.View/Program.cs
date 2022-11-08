using Bazar.Application;
using Bazar.Infrastructure;
using Bazar.View.Tools.Imagens;
using Bazar.View.Tools.Upload;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GerenciadorImagens>();
builder.Services.AddScoped<UnitOfUpload>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllersWithViews();

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
