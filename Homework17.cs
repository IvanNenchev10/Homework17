using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseApplication
{
    class Program
    {
        static void Main()
        {
            using (MyDataBaseEntities context = new MyDataBaseEntities())
            {
                Clients client = new Clients
                {
                    FirstName = "Ivan",
                    SecondName = "Petrov",
                    Family = "Hristov",
                    Year = 1996
                };
                context.Clients.Add(client);
                context.SaveChanges();

                client = context.Clients.FirstOrDefault(x => x.FirstName == "Ivan");
                Console.WriteLine("{0}", client.Id);

                client = context.Clients.FirstOrDefault(x => x.Year == 1996);
                client.Year = 2000;
                context.SaveChanges();

                client = context.Clients.FirstOrDefault(x => x.Id == 1);
                context.Clients.Remove(client);
                context.SaveChanges();

                BankAccount account = new BankAccount
                {
                    Name = "Account1",
                    IBAN = "SP12356",
                    Sum = 5000,
                    ClientId = 1,
                    isPaid = 0
                };
                context.BankAccount.Add(account);
                context.SaveChanges();

                account = context.BankAccount.FirstOrDefault(x => x.ClientId == 1);
                Console.WriteLine("{0}", account.Name);

                account = context.BankAccount.FirstOrDefault(x => x.ClientId == 1);
                account.ClientId = 2;
                context.SaveChanges();

                account = context.BankAccount.FirstOrDefault(x => x.Sum == 5000);
                context.BankAccount.Remove(account);
                context.SaveChanges();

            }
        }
    }
}
