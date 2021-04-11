using Library_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_dotnet.Actions
{
    public class ReturnBooks
    {
        public List<Loan> ReturnBook(List<Loan> LoanedBooks, int bookId)
        {
            Loan loanedBook = new();
            if (LoanedBooks.Count > 0)
            {
                loanedBook = LoanedBooks.Find(x => x.BookId == bookId);
                if (loanedBook != null)
                {
                    LoanedBooks.Remove(loanedBook);
                    CheckReturnDate(loanedBook.DateOfReturn);
                    Console.WriteLine("Book was successfully returned");
                    return LoanedBooks;
                }
                else
                {
                    Console.WriteLine("Loned book with such ID, was not found");
                    return LoanedBooks;
                }
            }
            else
            {
                Console.WriteLine("There are no loned books");
                return LoanedBooks;
            }
        }
        public void CheckReturnDate(DateTime ReturnDate)
        {
            if (ReturnDate < DateTime.Today)
                Console.WriteLine($"Return date: {ReturnDate} - Todays date: {DateTime.Today}. Return is late");
        }
    }
}
