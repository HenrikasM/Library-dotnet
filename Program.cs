using Library_dotnet.Actions;
using Library_dotnet.DataStorage;
using Library_dotnet.Models;
using NUnitLite;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Library_dotnet
{
    public class Program
    {

        static void Main(string[] args)
        {
            bool Continue = true;
            List<Loan> LoanedBooks = new();
            Console.WriteLine("Welcome to the library!");
            Console.WriteLine();
            while (Continue)
            {

                Console.WriteLine("Available actions: Add/Take/Return/List/Delete");
                Console.WriteLine("Please select action: ");
                switch (Console.ReadLine())
                {
                    case "Add":
                        CreateBooks create = new();
                        create.CreateBook();
                        break;
                    case "Take":
                        TakeBooks take = new();
                        LoanedBooks = take.TakeBook(LoanedBooks);
                        break;
                    case "Return":
                        ReturnBooks returnBook = new();
                        Console.WriteLine("Insert bookd Id: ");
                        LoanedBooks = returnBook.ReturnBook(LoanedBooks, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "List":
                        FindBooks find = new();
                        find.ListBooks(LoanedBooks);
                        break;
                    case "Delete":
                        DeleteBooks delete = new();
                        Console.WriteLine("Insert book id");
                        delete.DeleteById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("Option was not found");
                        break;
                }
                Console.WriteLine("Do you want to continue?(Y/N)");
                if (Console.ReadLine() == "Y")
                    Continue = true;
                else
                    Continue = false;
            }
            new AutoRun(Assembly.GetExecutingAssembly())
                       .Execute(new string[] { "/test:Library_dotnet.Tests.Library_Dotnet_Test" });
            Console.ReadKey();
        }
    }
}
