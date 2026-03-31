
using ApplicationComponent;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");

var services = new ServiceCollection();
services.AddDbContext<ItemsDbContext>(options => options.UseSqlServer(connectionString));

services.AddTransient<IRepository, ItemRepository>();
services.AddTransient<IService, ItemService>();

var serviceProvider = services.BuildServiceProvider();
var itemService = serviceProvider.GetRequiredService<IService>();           

while (true)
{
    try
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1 - Agregar una tarea");
        Console.WriteLine("2 - Mostrar una tarea");
        Console.WriteLine("3 - Salir");
        Console.Write("Opcion: ");
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                Console.Write("Ingrese el nombre de la tarea: ");
                string title = Console.ReadLine();
                await itemService.AddAsync(title);
                Console.WriteLine("Tarea agregada.");
                break;
            case "2":
                Console.WriteLine("Mostrar todas las tareas... ");
                var items = await itemService.GetAsync();
                foreach(var item in items)
                {  Console.WriteLine(item.Title); }
                break;
            case "3":
                return;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }


    }
    catch (Exception ex) { 
        Console.WriteLine(ex.ToString());
    }



}