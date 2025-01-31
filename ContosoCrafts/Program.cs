using ContosoCrafts.Models;
using ContosoCrafts.Services;
using System.Text.Json;

namespace ContosoCrafts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<JsonFileProductService>();
            builder.Services.AddControllers();
            builder.Services.AddServerSideBlazor();

            var app = builder.Build();

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

            //Endpoints for API
            app.MapRazorPages();

            //api for controller
            app.MapControllers();

            //api for blazor
            app.MapBlazorHub();
            //manually adding logic 
            //app.MapGet("/products", (context) =>
            //{
            //    var products = app.Services.GetService<JsonFileProductService>().GetProducts();
            //    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
            //    return context.Response.WriteAsync(json);
            //});

            app.Run();
        }
    }
}
