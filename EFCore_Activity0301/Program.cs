using EFCore_Activity0301;
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

class Program
{
    private static IConfigurationRoot _configuration;
    private static DbContextOptionsBuilder<AdventureWorksContext> _optionsBuilder;

    static void Main(string[] args)
    {
        BuildOptions();
        ListPeople();
    }

    static void BuildOptions()
    {
        _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        _optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext>();
        _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));
    }

    static void ListPeople()
    {
        using (var db = new AdventureWorksContext(_optionsBuilder.Options))
        {
            var people = db.People.OrderByDescending(x => x.LastName).Take(20).ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }
    }

}