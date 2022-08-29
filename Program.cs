using System;
using System.Collections.Generic;
namespace Library_Management_System
{

    internal class Program
    {
        static bool isTrue = true;
        static List<Books> bookList = new List<Books>();
        static List<Borrowing> borrowList = new List<Borrowing>();


        Borrowing obj1 = new Borrowing();

        static void Main(string[] args)
        {

            Console.WriteLine("-[]-[]-[]-[]-[]---Library Management System---[]-[]-[]-[]-[]-");
            Console.WriteLine("\n\nEnter your name:");
            Console.WriteLine("\n----------------------------------");
            string myName = Console.ReadLine();


            Console.Clear();
            Console.WriteLine("Welcome {0} to the Library.....!", myName);
            Console.WriteLine("\n\nPlease Enter your password:");
            Console.WriteLine("----------------------------------------");
            string myPassword = Console.ReadLine();


            if (myPassword == "uday@123")
            {
                Console.Clear();

                while (isTrue)
                {


                    Console.WriteLine("|----------------LIST----------------------|");
                    Console.WriteLine("|         1.Librarian                      |");
                    Console.WriteLine("|         2.Borrower                       |");
                    Console.WriteLine("|           3.Exit                         |");
                    Console.WriteLine("|__________________________________________|");


                    Console.WriteLine("\nSelect where you want to go from list:");
                    int myOption = int.Parse(Console.ReadLine());

                    switch (myOption)
                    {
                        case 3:
                            Console.WriteLine("Thank you Visit Again......!");
                            isTrue = false;
                            break;

                        case 2:
                            Program obj = new Program();
                            obj.Borrower();

                            break;

                        case 1:

                            Librarian();
                            break;


                        default:
                            Console.WriteLine("Please enter valid option!");
                            break;

                    }

                }
            }
            else
            {
                Console.WriteLine("Wrong Password! Please try again..");
                Program.Main(args);      // calling Main method 

            }


        }

        public void Borrower()
        {
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|            BORROWER-LIST               |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|        1. Borrow the book              |");
            Console.WriteLine("|        2.Return the book               |");
            Console.WriteLine("|       3.Return to Main Menu            |");
            Console.WriteLine("|________________________________________|");

            Console.WriteLine("Select for the Borrower List :");
            int myOption = int.Parse(Console.ReadLine());

            switch (myOption)
            {
                case 3:
                    Console.WriteLine("Thank you Visit Again to library..");
                    Console.Clear();
                    break;

                case 2:
                    returnBook(); //returning books
                    Borrower();
                    break;

                case 1:
                    borrowBook(); // for borrow books
                    Borrower();
                    break;


                default:
                    Console.WriteLine("Please enter valid option!");
                    break;

            }
        }

        public static void borrowBook()
        {
            Books books = new Books();
            Borrowing borrowing = new Borrowing();
            Console.WriteLine("---------------------------------------------");
            Console.Write("User ID: {0}", (borrowing.userID = borrowList.Count + 1));
            Console.WriteLine();
            Console.WriteLine("Enter User Name:");
            borrowing.userName = Console.ReadLine();

            Console.WriteLine("Enter Book ID:");
            borrowing.borrowBookID = int.Parse(Console.ReadLine());

            Console.WriteLine("Number of Books want to borrow:");
            borrowing.borrowCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Address:");
            borrowing.userAddress = Console.ReadLine();

            borrowing.borrowDate = DateTime.Now;
            Console.WriteLine("Date:- {0} and Time:- {1}", borrowing.borrowDate.ToShortDateString(), borrowing.borrowDate.ToShortTimeString());
            Console.WriteLine("\n      Book Issued Successfully!       ");


            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == borrowing.borrowBookID))
            {
                foreach (Books findID in bookList)
                {
                    int totalCount = findID.bookCount - borrowing.borrowCount;
                    if (findID.bookCount >= totalCount && totalCount >= 0)
                    {
                        if (findID.bookID == borrowing.borrowBookID)
                        {
                            findID.bookCount = totalCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} Books are found in the library:)", findID.bookCount);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book {0} not found in the Library:(", borrowing.borrowBookID);

            }
            borrowList.Add(borrowing);


        }

        public static void returnBook()
        {
            Books books = new Books();
            Console.WriteLine("-------------------------------------------");
            Console.Write("Enter Book ID: ");
            int returnBookId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books want to return: ");
            int returnBookCount = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------");

            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == returnBookId))
            {
                foreach (Books addReturnBook in bookList)
                {
                    if (addReturnBook.numberOfBookX >= returnBookCount + addReturnBook.bookCount)
                    {
                        if (addReturnBook.bookID == returnBookId)
                        {
                            addReturnBook.bookCount = addReturnBook.bookCount + returnBookCount;
                            Console.WriteLine("Book  {0}   get  return  Successfully to the library !", returnBookId);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You connot borrow that much books");
                        break;
                    }
                }
            }

        }


        public static void Librarian()
        {



            //Console.Clear();
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("|         LIBRARIAN-LIST                |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|       1.Add The Book                  |");
            Console.WriteLine("|      2.Delete The Book                |");
            Console.WriteLine("|      3.Search The Book                |");
            Console.WriteLine("|     4.Display Book Data               |");
            Console.WriteLine("|    5.Return to Main Menu              |");
            Console.WriteLine("|_______________________________________|");

            Console.WriteLine("Select From the List:");
            int myOption = int.Parse(Console.ReadLine());

            switch (myOption)
            {
                case 5:
                    Console.WriteLine("Thank you Visit Again...!");
                    Console.Clear();
                    break;



                case 4:
                    displayBookData();  //diplay book id
                    Librarian();
                    break;

                case 3:
                    searchBook();  //searching book
                    Librarian();
                    break;

                case 2:
                    deleteBook();  //Deleting book
                    Librarian();
                    break;

                case 1:
                    addBook();  //Adding book 
                    Librarian();
                    break;


                default:
                    Console.WriteLine("Please enter valid option!");
                    break;

            }


        }



        public static void displayBookData()
        {
            Books books = new Books();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Book ID\t" +
                   "\tBook Name\t" +
                   "Book Price\t" +
                   "Book Available\t" +
                   "Total Book Added");
            foreach (Books show in bookList)
            {
                Console.WriteLine("{0} {1,15} {2,20} {3,20} {4,20}", show.bookID, show.bookName, show.bookPrice, show.bookCount, show.numberOfBookX);
            }
            Console.WriteLine("------------------------------------------------------------------------------");
        }
        public static void addBook()// function for adding books
        {
            Books books = new Books();
            Console.WriteLine("Book ID:{0}", books.bookID = bookList.Count + 1); //update bookList by 1 
            Console.Write("Book Name:");
            books.bookName = Console.ReadLine();
            Console.Write("Book Price:");
            books.bookPrice = int.Parse(Console.ReadLine());
            Console.Write("Number of Books want to add in cart:");
            books.numberOfBookX = books.bookCount = int.Parse(Console.ReadLine());
            bookList.Add(books);

        }

        public static void searchBook() //function for searching books
        {


            Books books = new Books();
            Console.Write("Enter BookID:");
            int findBook = int.Parse(Console.ReadLine());

            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == findBook))
            {
                foreach (Books id in bookList)
                {
                    if (id.bookID == findBook)
                    {
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Book ID:{0}\n" +
                            "Book Name: {1}\n" +
                            "Book Price: {2}\n" +
                            "Book Available: {3}", id.bookID, id.bookName, id.bookPrice, id.bookCount);
                        Console.WriteLine("-----------------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine("Book ID {0} not found in Database", findBook);
            }

        }

        public static void deleteBook() // function for deleting book
        {


            Books books = new Books();
            Console.WriteLine("Enter Book ID to be Deleted:");
            int deleteBook = int.Parse(Console.ReadLine());

            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == deleteBook))
            {
                bookList.RemoveAt(deleteBook - 1);
                Console.WriteLine("Book ID {0} has deleted Successfully!", deleteBook);
            }
            else
            {
                Console.WriteLine("Book ID - {0} not exist!", deleteBook);
            }
            bookList.Add(books);

        }
    }
}
