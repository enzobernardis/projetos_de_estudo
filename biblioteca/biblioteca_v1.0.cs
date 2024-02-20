using System;
using System.Collections.Generic;
using System.Linq;

class Program {
  public List<Book> books = new List<Book>();
  
  public class Book {
    public string name;
    public string author;
    public int pages;
    public int year;
  }
  
  public static void Main (string[] args) {
    Program program = new Program();
    bool run = true;
    program.Faq();
    
    while(run) {
      Console.WriteLine("\nWhat you want to do?");
      switch(Console.ReadLine().ToLower().Replace(" ", "")) {
      case "faq":
        program.Faq();
        break;
      case "add":
        program.AddBook();
        break;
      case "delete":
        program.DeleteBook();
        break;
      case "show":
        program.ShowBooks();
        break;
      case "showone":
        program.ShowOneBook();
        break;
      case "exit":
        Console.WriteLine("Ending the program");
        run = false;
        break;
      default:
        Console.WriteLine("Invalid input! Try again");
        break;
      }
    }
  }

  public void Faq() {
    Console.WriteLine("Instructions\n\nAdd - add new book\nDelete - delete book\nShow - show all books\nShow one - show one specific book and characteristics\nExit - end");
    Console.WriteLine("To see again the instructions, digital \"FAQ\"");
  }
  
  public void AddBook() {
    Book book = new Book();

    while(true) {
      Console.WriteLine("Enter book name:");
      book.name = Console.ReadLine();

      Console.WriteLine("Enter book author:");
      book.author = Console.ReadLine();

      Console.WriteLine("Enter book pages:");
      book.pages = int.Parse(Console.ReadLine());

      Console.WriteLine("Enter book year:");
      book.year = int.Parse(Console.ReadLine());

      if(!(book.name == null || book.author == null || book.pages == 0 || book.year == 0)) {
        books.Add(book);
        Console.WriteLine("Book added!");
        break;
      } else {
        Console.WriteLine("Invalid input! Try again");
      }
    }
  }
  
  public void DeleteBook() {
    Console.WriteLine("Which book you want to delete?");
    string input = Console.ReadLine();
    bool bookFound = false;

    for(int i = 0; i < books.Count; i++) {
      if(books[i].name == input) {
        books.RemoveAt(i);
        Console.WriteLine("Book deleted!");
        bookFound = true;
        break;
      }
    }

    if(!(bookFound)) {
      Console.WriteLine("Book not found!");
    }
  }

  public void ShowBooks() {
    Program program = new Program();
    Console.WriteLine("In which order you want to show books? alphabetical order or release order?");
    string input = Console.ReadLine().ToLower();
    int i = 1;

    while(true) {
      if(input == "alphabetical order") {
        foreach(Book book in books.OrderBy(x => x.name)) {
          Console.WriteLine($"{i}. {book.name} ({book.year})");
          i++;
        }
        break;
      } else if(input == "release order") {
        foreach(Book book in books.OrderBy(x => x.year)) {
          Console.WriteLine($"{i}. {book.name} ({book.year})");
          i++;
        }
        break;
      } else {
        Console.WriteLine("Invalid input! Try again");
      }
    }
  }

  public void ShowOneBook() {
    Console.WriteLine("Which book you want to show?");
    string input = Console.ReadLine();

    foreach(Book book in books) {
      if(book.name == input) {
        Console.WriteLine($"Name: {book.name}\nAuthor: {book.author}\nPages: {book.pages}\nRelease Year: {book.year}");
        break;
      }
    }
  }
}
