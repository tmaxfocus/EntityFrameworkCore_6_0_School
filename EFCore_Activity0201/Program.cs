// See https://aka.ms/new-console-template for more information
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


class Program
{
    private static IConfigurationRoot _configuration;
    private static DbContextOptionsBuilder<AdventureWorksContext> _optionBuilder;
    static void Main(string[] args)
    {
        BuildConfiguration();
        BuilOptions();
        ListPeople();
    }

    static void BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        _configuration = builder.Build();

        Console.WriteLine($"CNSTR: {_configuration.GetConnectionString("AdventureWorks")}");
    }

    static void BuilOptions()
    {
        _optionBuilder = new DbContextOptionsBuilder<AdventureWorksContext>();
        _optionBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));
    }

    static void ListPeople()
    {
        using(var db = new AdventureWorksContext(_optionBuilder.Options))
        {
            var people = db.People.OrderByDescending(x => x.LastName).Take(20).ToList();


            foreach(var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }
    }
}

 



