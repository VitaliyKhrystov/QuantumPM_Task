using Microsoft.EntityFrameworkCore;
using QuantumPM_Task.Domain;
using QuantumPM_Task.Domain.Repository;
using QuantumPM_Task.Domain.Repository.Abstract;

namespace QuantumPM_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddDbContext<AppDbContext>(
                             options => options.UseNpgsql(builder.Configuration.GetSection("ConnectionString").Value));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddTransient<INoteRepository, NoteRepositoryEF>();
            builder.Services.AddAutoMapper(typeof(AppMappingProfile));

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}