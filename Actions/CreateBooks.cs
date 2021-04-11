using Library_dotnet.DataStorage;
using Library_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Library_dotnet.Actions
{
    public class CreateBooks
    {
        private readonly Random random = new();
        public void CreateBook()
        {
            AssignValues(BookInput());
        }
        public void AssignValues(List<string> BookValues)
        {
            StorageActions serialize = new();
            serialize.Write(new Book
            {
                Id = random.Next(1000, 9999),
                Name = BookValues[0],
                Author = BookValues[1],
                Category = BookValues[2],
                Language = BookValues[3],
                Date = ConvertToDate(BookValues[4]),
                ISBN = BookValues[5]
            });
        }
        public List<string> BookInput()
        {
            List<string> BookValues = new();
            List<string> CurrentValue = InputValue();
            for (int x = 0; x < 6; x++)
            {
                Console.WriteLine($"Insert {CurrentValue[x]}");
                string value = Console.ReadLine();
                BookValues.Add(value);
            }
            return BookValues;
        }
        public List<string> InputValue()
        {
            List<string> currentValue = new();
            currentValue.Add("Name");
            currentValue.Add("Author");
            currentValue.Add("Category");
            currentValue.Add("Language");
            currentValue.Add("Publication date(yyyy-MM-dd)");
            currentValue.Add("ISBN");
            return currentValue;
        }
        public DateTime ConvertToDate(string date)
        {
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", new CultureInfo("lt-LT"), DateTimeStyles.None,
                out DateTime dateValue))
                return dateValue;
            else
                return DateTime.Today;
        }

    }
}
