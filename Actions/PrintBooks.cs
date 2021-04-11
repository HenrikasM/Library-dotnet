using Library_dotnet.DataStorage;
using Library_dotnet.Models;
using System;
using System.Collections.Generic;

namespace Library_dotnet.Actions
{
    public class PrintBooks
    {
        public void PrintBook(List<Book> books)
        {
            if (books.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-15} {4,-15} {5,-30} {6,-20}", "Id", "Name", "Author", "Category", "Language", "Date", "ISBN");
                foreach (Book book in books)
                {
                    if (book != null)
                        Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-15} {4,-15} {5,-30} {6,-20}", book.Id, book.Name, book.Author, book.Category, book.Language, book.Date, book.ISBN);
                }
                Console.WriteLine();
            }
        }
    }
}
