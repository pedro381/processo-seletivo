using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo.Data;
namespace ProcessoSeletivo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ProcessoSeletivoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProcessoSeletivoContext") ?? throw new InvalidOperationException("Connection string 'ProcessoSeletivoContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

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

            app.MapRazorPages();

            app.Run();
        }
    }
}
