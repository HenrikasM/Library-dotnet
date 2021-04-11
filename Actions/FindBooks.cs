using Library_dotnet.DataStorage;
using Library_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_dotnet.Actions
{
    public class FindBooks
    {
        public void ListBooks(List<Loan> loanedBooks)
        {
            PrintBooks print = new();
            Console.WriteLine("Select filter: All/Author/Category/Language/ISBN/Name/Taken/Available");
            switch (Console.ReadLine())
            {
                case "All":
                    print.PrintBook(FindAllBooks());
                    break;
                case "Author":
                    Console.WriteLine("Please insert Author: ");
                    print.PrintBook(FindBooksByAuthor(Console.ReadLine()));
                    break;
                case "Category":
                    Console.WriteLine("Please insert Category: ");
                    print.PrintBook(FindBooksByCategory(Console.ReadLine()));
                    break;
                case "Language":
                    Console.WriteLine("Please insert Language: ");
                    print.PrintBook(FindBooksByLanguage(Console.ReadLine()));
                    break;
                case "ISBN":
                    Console.WriteLine("Please insert ISBN: ");
                    print.PrintBook(FindBooksByISBN(Console.ReadLine()));
                    break;
                case "Name":
                    Console.WriteLine("Please insert Name: ");
                    print.PrintBook(FindBooksByName(Console.ReadLine()));
                    break;
                case "Taken":
                    print.PrintBook(FindBooksTaken(loanedBooks));
                    break;
                case "Available":
                    print.PrintBook(FindBooksAvailable(loanedBooks));
                    break;
                default:
                    Console.WriteLine("Option not found");
                    break;
            }
        }
        public List<Book> FindAllBooks()
        {
            StorageActions repo = new();
            if (repo.Read() != null)
                return repo.Read();
            else
            {
                Console.WriteLine("No books to display");
                return null;
            }
        }


        public Book FindBookByName(string name)
        {
            if (FindAllBooks() != null)
            {
                return Validation(FindAllBooks().Find(x => x.Name == name));
            }
            else
                return null;
        }

        public Book FindBookById(int id)
        {
            if (FindAllBooks() != null)
            {
                return Validation(FindAllBooks().Find((x => x.Id == id)));
            }
            else
                return null;
        }
        public List<Book> FindBooksByName(string name)
        {
            if (FindAllBooks() != null)
            {
                return Validation(FindAllBooks().FindAll(x => x.Name == name));
            }
            else
                return null;
        }
        public List<Book> FindBooksByAuthor(string author)
        {
            if (FindAllBooks() != null)
            {
                return Validation(FindAllBooks().FindAll(x => x.Author == author));
            }
            else
                return null;
        }
        public List<Book> FindBooksByCategory(string category)
        {
            if (FindAllBooks() != null)
            {
                return Validation(FindAllBooks().FindAll(x => x.Category == category));
            }
            else
                return null;
        }
        public List<Book> FindBooksByLanguage(string language)
        {
            if (FindAllBooks() != null)
            {
                return Validation(FindAllBooks().FindAll(x => x.Language == language));
            }
            else
                return null;
        }
        public List<Book> FindBooksByISBN(string isbn)
        {
            if (FindAllBooks() != null)
            {
                return Validation(FindAllBooks().FindAll(x => x.ISBN == isbn));
            }
            else
                return null;
        }
        public List<Book> FindBooksTaken(List<Loan> loaned)
        {
            List<Book> loanedBooks = new();
            if (loaned != null)
            {
                foreach (Loan loanedBook in loaned)
                {
                    loanedBooks.Add(Validation(FindAllBooks().Find(x => x.Id == loanedBook.BookId)));
                }
            }
            return loanedBooks;
        }
        public List<Book> FindBooksAvailable(List<Loan> loaned)
        {
            if (FindAllBooks() != null)
            {
                List<Book> availableBooks = new(FindAllBooks());
                foreach (Book loanedBook in FindBooksTaken(loaned))
                {
                    availableBooks.RemoveAll(x => x.Id == loanedBook.Id);
                }
                return availableBooks;
            }
            else
                return null;
        }
        public Loan FindLoanByBookId(int id, List<Loan> LoanedBooks)
        {
            TakeBooks taken = new();
            var AvaiableBooks = LoanedBooks;
            if (AvaiableBooks != null)
            {
                var loan = AvaiableBooks.Find(x => x.BookId == id);
                if (loan != null)
                    return loan;
                else
                    return null;
            }
            else
                return null;
        }

        public Book Validation(Book AvaiableBook)
        {
            if (AvaiableBook != null)
                return AvaiableBook;
            else
            {
                Console.WriteLine("Book was not found");
                return null;
            }
        }
        public List<Book> Validation(List<Book> AvaiableBooks)
        {
            if (AvaiableBooks != null)
                return AvaiableBooks;
            else
            {
                Console.WriteLine("Book was not found");
                return null;
            }
        }
    }
}
