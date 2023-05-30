namespace ClassIntroHW
{
    public class Library
    {
        public Book[] books = new Book[0];
        public Employee[] employees = new Employee[0];
        public string Title { get; set; }
        public string Location { get; set; }

        public void AddBook(Book book)
        {
            Array.Resize<Book>(ref books, books.Length + 1);
            books[^1] = book;
        }
        public void ShowAllBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}