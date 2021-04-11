using Library_dotnet.Actions;
using Library_dotnet.DataStorage;
using Library_dotnet.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Library_dotnet.Tests
{
    [TestFixture]
    class Library_Dotnet_Test
    {
        //Create Book object and insert into file. Checked by file size before and after insert.
        [Test]
        public void TestCase1()
        {
            //Prepare
            StorageActions storageActions = new();
            int BookAmount = storageActions.Read().Count;

            List<string> values = new();
            values.Add("Name");
            values.Add("Author");
            values.Add("Category");
            values.Add("Language");
            values.Add("2021-02-03");
            values.Add("ISBN");
            //Act
            CreateBooks create = new();
            create.AssignValues(values);

            int BookAmountAfterInsert = storageActions.Read().Count;
            //Assert
            Assert.AreEqual(BookAmount + 1, BookAmountAfterInsert);
        }

        //Take a book and find it with filters.
        [Test]
        public void TestCase2()
        {
            //Prepare
            Book loanedBook = new();
            FindBooks find = new();
            TakeBooks take = new();

            List<Loan> LoanedBooks = new();
            string ClientName = "Henrikas";
            int bookId = 0;
            string returnDate = "2021-04-11";

            //Act
            List<Loan> loans = new();
            loans = take.CreateLoan(ClientName, bookId, returnDate, LoanedBooks);

            loanedBook = find.FindBooksTaken(loans)[0];

            //Assert
            Assert.AreNotEqual(null, loans); //Loan created
        }

        //Return loaned book
        [Test]
        public void TestCase3()
        {
            //Prepare
            List<Loan> loans = new();
            FindBooks find = new();
            TakeBooks take = new();
            loans = take.CreateLoan("Henrikas", 0, "2021-04-10", loans);
            int LoanedBooksBefore = find.FindBooksTaken(loans).Count; //loaned books before return (1)
            ReturnBooks returnBook = new();
            //Act
            returnBook.ReturnBook(loans, 0);
            int LoanedBooksAfter = find.FindBooksTaken(loans).Count;

            //Assert
            Assert.AreEqual(1, LoanedBooksBefore); //Loaned book count before return
            Assert.AreEqual(0, LoanedBooksAfter); //Loaned book count after return
        }
        [Test]
        //Delete book
        public void TestCase4()
        {
            //Prepare

            List<string> values = new();
            values.Add("Name");
            values.Add("Author");
            values.Add("Category");
            values.Add("Language");
            values.Add("2021-02-03");
            values.Add("ISBN");
            CreateBooks create = new();
            create.AssignValues(values);

            FindBooks find = new();

            StorageActions storageActions = new();
            int BookAmountBefore = storageActions.Read().Count;
            //Act
            DeleteBooks delete = new();
            delete.DeleteById(find.FindBookByName("Name").Id);
            int BookAmountAfter = storageActions.Read().Count;
            //Assert
            Assert.AreEqual(BookAmountBefore - 1, BookAmountAfter); //Book amount should be -1 after deletion
        }


    }
}
