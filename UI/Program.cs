using BLL.Interfaces;
using BLL.Profiles;
using BLL.Services;
using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace UI
{
    public class Program
    {
        private IPersonService _personService;
        private ICompanyService _companyService;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddAutoMapper(typeof(PersonProfile), typeof(CompanyProfile));
                    services.AddTransient<Program>();
                    services.AddTransient<IPersonService, PersonService>();
                    services.AddTransient<ICompanyService, CompanyService>();
                    services.AddTransient<IRepository<Person>, PersonRepository>();
                    services.AddTransient<IRepository<Company>, CompanyRepository>();
                    services.AddTransient<ListContext>();
                });
        }

        public Program(IPersonService personService, ICompanyService companyService)
        {
            _personService = personService;
            _companyService = companyService;
        }

        public void Run()
        {
            Console.WriteLine("Main: Start...");
            Console.WriteLine();

            Console.WriteLine($"Company with ID 1 has {_companyService.GetEmployeeCount(1)} employees:");
            _personService.GetPersonsWorksOn(1).ForEach(x => Console.WriteLine($"Name: {x.Name} \t Age: {x.Age}"));
            Console.WriteLine();

            Console.WriteLine($"Company with ID 2 has {_companyService.GetEmployeeCount(2)} employees:");
            _personService.GetPersonsWorksOn(2).ForEach(x => Console.WriteLine($"Name: {x.Name} \t Age: {x.Age}"));
            Console.WriteLine();

            Console.WriteLine("Main: Finish...");
        }
    }
}
