using EntityFramework.Models;
using System;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateModel();
        }
        public static async Task CreateModel()
        {
            var @newCustomer = new Customer();
            Console.WriteLine("Enter your name: ");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your lastName: ");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Enter your middleName: ");
            newCustomer.MiddleName = Console.ReadLine();
            Console.WriteLine("Enter you DateBirth (ex: yyyy-mm-dd): ");
            newCustomer.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter your DocumentNo: ");
            newCustomer.DocumentNumber = Console.ReadLine();



            using (AppDbContext context = new AppDbContext())
            {
                context.Add(newCustomer);
                await context.SaveChangesAsync();
            }
        }
    }

}
