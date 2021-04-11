using Library_dotnet.DataStorage;
using Library_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_dotnet.Actions
{
    public class TakeBooks
    {
        public List<Loan> TakeBook(List<Loan> LoanedBooks)
        {
            if (LoanedBooks.Count > 3)
            {
                Console.WriteLine("Book limit exceeded");
                return LoanedBooks;
            }
            else
            {
                Console.WriteLine("Customer name: ");
                string CustomerName = Console.ReadLine();

                Console.WriteLine("Book name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Return date(yyyy-MM-dd): ");
                string date = Console.ReadLine();


                FindBooks find = new();
                Book book = find.FindBookByName(name);
                if (book != null)
                {
                    Console.WriteLine($"Book {book.Id}, Book {name}, Customer name: {CustomerName}, Date of return: {ReturnDate(date)} ");
                    return CreateLoan(CustomerName, book.Id, date, LoanedBooks);
                }

                else
                    Console.WriteLine("Book was not found");
                return LoanedBooks;
            }
        }
        public List<Loan> CreateLoan(string CustomerName, int bookId, string date, List<Loan> LoanedBooks)
        {
            LoanedBooks.Add(
                  new Loan
                  {
                      CustomerName = CustomerName,
                      BookId = bookId,
                      DateOfReturn = ReturnDate(date)
                  });
            return LoanedBooks;
        }
        public static DateTime ReturnDate(string date)
        {
            CreateBooks create = new CreateBooks();
            DateTime validatedDate = create.ConvertToDate(date);
            if (validatedDate > DateTime.Today.AddMonths(2))
                return DateTime.Today.AddMonths(2);
            else
                return validatedDate;
        }

    }
}
