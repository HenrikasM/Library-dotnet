using System;
namespace Library_dotnet.Models
{
    //Domain to track loaned books
    public class Loan
    {
        public string CustomerName { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfReturn { get; set; }
    }
}
