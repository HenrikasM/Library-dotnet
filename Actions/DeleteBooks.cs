using Library_dotnet.DataStorage;
using Library_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_dotnet.Actions
{
    public class DeleteBooks
    {
        public void DeleteById(int id)
        {
            FindBooks find = new();
            List<Book> books = new();
            books = find.FindAllBooks();
            books.RemoveAll(x => x.Id == find.FindBookById(id).Id);
            StorageActions StorageAction = new();
            StorageAction.Delete(books);
            Console.WriteLine("Book deleted");
        }
    }
}
