using Rest_api_assignments;

namespace Rest_api_Assignments;

class Program
{
    static void Main(string[] args)
    {
    
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHost =>
            {
                webHost.UseStartup<Startup>();
            });
    }
}







