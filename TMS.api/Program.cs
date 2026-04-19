
using Microsoft.EntityFrameworkCore;
using TMS.api.Extensions;
using TMS.api.Mappings;
using TMS.api.Persistance;
using TMS.api.Shared;

namespace TMS.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connString);
            });
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
                cfg.AllowNullCollections = true;
            }, typeof(MappingProfiles));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.ConfigureServices();
            builder.Services.ConfigureRepositories();
            builder.Services.ConfigureUnitOfWork();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandler>();

            app.MapControllers();

            app.Run();
        }
    }
}
