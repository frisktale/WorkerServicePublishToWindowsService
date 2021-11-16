using Serilog;
using System.Text;
using WorkerService1;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
        .Enrich.FromLogContext()
        .WriteTo.File(Path.Combine(AppContext.BaseDirectory, "serilogTest.txt")))
    .Build();
using var scope = host.Services.CreateScope();
var env = scope.ServiceProvider.GetService<IHostEnvironment>();

var base1 = env.ContentRootPath;
var base2 = AppContext.BaseDirectory;
var base3 = Directory.GetCurrentDirectory();
var base4 = AppDomain.CurrentDomain.BaseDirectory;
var finalstr = $"env.ContentRootPath : {base1}\nAppContext.BaseDirectory : {base2}\nDirectory.GetCurrentDirectory() : {base3}\nAppDomain.CurrentDomain.BaseDirectory : {base4}";
//await File.WriteAllTextAsync(@"D:\workspace\path.txt",finalstr);
var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
logger.LogInformation(finalstr);
await host.RunAsync();
