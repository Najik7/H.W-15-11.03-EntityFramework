using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static async Task Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                await Read();
                await Create();
                Console.ReadLine();
            }
            
        }

        private static async Task Create()
        {
            var @newCustomer = new Customer();

            Console.WriteLine("Enter your FirstName: ");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your LastName: ");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Enter your MiddleName: ");
            newCustomer.MidlleName = Console.ReadLine();
            Console.WriteLine("Enter you DateBirth(ex: yyyy - mm - dd)");
            newCustomer.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter your DocumentNo: ");
            newCustomer.DocumentNumber = Console.ReadLine();

            using(var creatcnt = new AppDbContext())
            {
                creatcnt.Add(newCustomer);
                await creatcnt.SaveChangesAsync();
            }

        }


        public static async Task Read()
        {
            using (var alifcontext = new AppDbContext())
            {
                var customers = alifcontext.Customers;
                await customers.ForEachAsync(customer => Console.WriteLine($"Id: {customer.Id}\t FirstName: {customer.FirstName}\t LastName: {customer.LastName}\t MiddleName: {customer.MidlleName}\t " +
                                      $"Date of Birth: {customer.DateOfBirth}\t DocumentNumber: {customer.DocumentNumber}"));
            }
        }
    }

}
