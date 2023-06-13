using FullStack.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // builder.Services.AddDbContext<FullStackDbContext>(options =>
        // options.UseSqlServer(builder.Configuration.GetConnectionString("FullStackConnetionString"))
        //options.UseNpgsql(builder.Configuration.GetConnectionString("FullStackConnetionString")));
        builder.Services.AddEntityFrameworkNpgsql().AddDbContext<FullStackDbContext>(opt =>
         opt.UseNpgsql(builder.Configuration.GetConnectionString("FullStackConnetionString")));
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}