using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class BookBLL
    {
        BookDAL bookdb = new BookDAL();
        public int AddBook(Book b)
        {
            int row = bookdb.Addbook(b);
            return row;
        }

        public Book SearchBookName(string Name)
        {
            Book book_s = bookdb.SelectBookName(Name);
            return book_s;
        }

        public Book SearchByBookNo(string No)
        {
            Book book = bookdb.SelectByBookNo(No);
            return book;
        }

        public List<Book> SearchAllBooks()
        {
            List<Book> books = bookdb.SelectAllBooks();
            return books;
        }

        public List<Book> ListBookByName(string Name)
        {
            List<Book> book = bookdb.SelectByBookName(Name);
            return book;
        }

        public int DeleteBook(string No)
        {
            int row = bookdb.DeleteByNo(No);
            return row;
        }

        public int UpdateBook(Book b)
        {
            int row = bookdb.UpdateByNo(b);
            return row;
        }


    }
}
