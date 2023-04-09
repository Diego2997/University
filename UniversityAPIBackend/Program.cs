using Microsoft.EntityFrameworkCore;
using UniversityAPIBackend.DataAccess;
using UniversityAPIBackend.Interface;
using UniversityAPIBackend.Services;

namespace UniversityAPIBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            const string CONNECTIONNAME = "UniversityDB";

            string connectionString =  builder.Configuration.GetConnectionString(CONNECTIONNAME);
            builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


            builder.Services.AddControllers();

            //4- Add Custom Services (folder Services)
            builder.Services.AddScoped<IStudentService,StudentService>();
            builder.Services.AddScoped<IUserService, UserService>();

            //TODO : Add the rest of services
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //5_ CORS Configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

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

            //6_ Tell app to use CORS
            app.UseCors("CorsPolicy");

            app.Run();
        }
    }
}