﻿using static System.Reflection.Metadata.BlobBuilder;

namespace ClassIntroHW
{
    public class Client : Person
    {
        public Book[] takenBooks = new Book[0];
        public int DebtInDollars { get; set; }

        public void TakeBook(Book book)
        {
            Array.Resize<Book>(ref takenBooks, takenBooks.Length + 1);
            takenBooks[^1] = book;
            takenBooks[^1].GiveClientBook(this);
        }
        public void ShowTakenBooks()
        {
            foreach (var book in takenBooks)
            {
                Console.WriteLine(book);
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Phone: {PhoneNum}, Debt: {DebtInDollars}";
        }
    }
}