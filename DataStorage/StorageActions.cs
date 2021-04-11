using Library_dotnet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Library_dotnet.DataStorage
{
    public class StorageActions
    {
        public static string path = $"{AppDomain.CurrentDomain.BaseDirectory} \\..\\..\\..\\..\\DataStorage\\DataFiles\\storage.json";
        public void Write(Book book)
        {
            List<Book> books = new(Read());
            books.Add(book);
            string BooksJsonString = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(path, BooksJsonString);
        }
        public List<Book> Read()
        {
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(Parse());
            if (books != null)
                return books;
            else
                return new List<Book>();
        }
        public static string Parse()
        {
            return File.ReadAllText(path);
        }

        public void Delete(List<Book> books)
        {
            string BooksJsonString = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(path, BooksJsonString);
        }

    }
}
