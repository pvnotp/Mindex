using CodeChallenge.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public class Program
{

    public static void Main(string[] args)
    {
        new App().Configure(args).Run();
    }
}