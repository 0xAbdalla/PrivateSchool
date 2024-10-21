
using Microsoft.EntityFrameworkCore;
using PrivateSchool.Data;

namespace PrivateSchool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connection = "Data Source=DESKTOP-40A6L64\\SQLEXPRESS;Database=Private_School;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;";
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
