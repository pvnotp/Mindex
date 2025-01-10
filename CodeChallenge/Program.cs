using CodeChallenge.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public class Program
{

    public static void Main(string[] args)
    {
        //var builder = WebApplication.CreateBuilder(z);
        //builder.Services.AddSwaggerGen();
        //var app = builder.Build();
        //app.UseSwagger();
        //app.UseSwaggerUI();
        new App().Configure(args).Run();
    }
}