using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookDAL
    {
        SqlConnection con;//使用SqlConnection对象连接数据库
        SqlCommand cmd; //使用SqlCommand对象，负责SQL语句的执行和存储过程的调用
        SqlDataReader rd;//对SQL语句或存储过程执行后的结果进行操作，返回的是一个“流”，可以直接一行一行的读取数据集（rd.Read()，读到一行数据则返回true）

        /// <summary>
        /// 向数据表T_User中添加一条记录，各字段值为Book对象的属性值
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public int Addbook(Book usr)
        {
            int row;
            try
            {
                con = DBConnection.CreateDBConnection();
                string sql = "insert into T_User (BookNo,BookName,Author,Publisher,Format,Page,Price,EnterDate,Borrow) values(@BookNo,@BookName,@Author,@Publisher,@Format,@Page,@Price,@EnterDate,@Borrow)";//BookNo未自动增值
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@BookNo", usr.BookNo);
                cmd.Parameters.AddWithValue("@BookName", usr.BookName);
                cmd.Parameters.AddWithValue("@Author", usr.Author);
                cmd.Parameters.AddWithValue("@Publisher", usr.Publisher);
                cmd.Parameters.AddWithValue("@Format", usr.Format);
                cmd.Parameters.AddWithValue("@Page", usr.Page);
                cmd.Parameters.AddWithValue("@Price", usr.Price);
                cmd.Parameters.AddWithValue("@EnterDate", usr.EnterDate);
                cmd.Parameters.AddWithValue("@Borrow", usr.Borrow);
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return row;
        }
        /// <summary>
        /// 按书名查询
        /// </summary>
        /// <param name="BookName"></param>
        /// <returns></returns>
        public Book SelectBookName(string BookName)
        {
            Book users = new Book();
            try
            {
                con = DBConnection.CreateDBConnection();
                string sql = "select * from T_User where BookName like '%" + BookName + "%'";
                cmd = new SqlCommand(sql, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Book usr = new Book();
                    usr.BookNo = rd.GetString(0);
                    usr.BookName = rd.GetString(1);
                    usr.Author = rd.GetString(2);
                    usr.Publisher = rd.GetString(3);
                    usr.Format = rd.GetInt32(4);
                    usr.Page = rd.GetInt32(5);
                    usr.Price = Convert.ToSingle(rd.GetValue(6));
                    usr.EnterDate = rd.GetString(7);
                    usr.Borrow = rd.GetString(8);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return users;

        }
        /// <summary>
        /// 按书号查找
        /// </summary>
        /// <param name="BookNo"></param>
        /// <returns></returns>
        public Book SelectByBookNo(string BookNo)
        {
            Book book = new Book();
            try
            {
                con = DBConnection.CreateDBConnection();
                string sql = "select * from T_User where BookNo like '%" + BookNo + "%'";
                cmd = new SqlCommand(sql, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    book.BookNo = rd.GetString(0);
                    book.BookName = rd.GetString(1);
                    book.Author = rd.GetString(2);
                    book.Publisher = rd.GetString(3);
                    book.Format = rd.GetInt32(4);
                    book.Page = rd.GetInt32(5);
                    book.Price = Convert.ToSingle(rd.GetValue(6));
                    book.EnterDate = rd.GetString(7);
                    book.Borrow = rd.GetString(8);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return book;
        }
        /// <summary>
        /// 按书名查找，后来连接到了借阅那部分吧，懒改了
        /// </summary>
        /// <param name="BookName"></param>
        /// <returns></returns>
        public List<Book> SelectByBookName(string BookName)
        {
            List<Book> users = new List<Book>();
            try
            {
                con = DBConnection.CreateDBConnection();
                string sql = "select * from T_User where BookNo like '%" + BookName + "%'";
                cmd = new SqlCommand(sql, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Book bk = new Book();
                    bk.BookNo = rd.GetString(0);
                    bk.BookName = rd.GetString(1);
                    bk.Author = rd.GetString(2);
                    bk.Publisher = rd.GetString(3);
                    bk.Format = rd.GetInt32(4);
                    bk.Page = rd.GetInt32(5);
                    bk.Price = Convert.ToSingle(rd.GetValue(6));
                    bk.EnterDate = rd.GetString(7);
                    bk.Borrow = rd.GetString(8);
                    users.Add(bk);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return users;

        }
        /// <summary>
        /// 删除该书籍
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public int DeleteByNo(string No)
        {
            int row;
            try
            {
                con = DBConnection.CreateDBConnection();
                string sql = string.Format("delete from T_User where BookNo='{0}'", No);
                cmd = new SqlCommand(sql, con);
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return row;
        }
        /// <summary>
        /// 对书籍信息进行更行操作
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int UpdateByNo(Book book)
        {
            int row;
            try
            {
                con = DBConnection.CreateDBConnection();
                string sql = "update T_User set BookNo=@BookNo,BookName=@BookName,Author=@Author,Publisher=@Publisher,Format=@Format,Page=@Page,Price=@Price,EnterDate=@EnterDate,Borrow=@Borrow where BookNo=@BookNo";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BookNo", book.BookNo);
                cmd.Parameters.AddWithValue("@BookName", book.BookName);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@Format", book.Format);
                cmd.Parameters.AddWithValue("@Page", book.Page);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@EnterDate", book.EnterDate);
                cmd.Parameters.AddWithValue("@Borrow", book.Borrow);
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return row;
        }
        /// <summary>
        /// 查询所有书籍
        /// </summary>
        /// <returns>泛型集合Books</returns>
        public List<Book> SelectAllBooks()
        {
            List<Book> users = new List<Book>();
            try
            {
                con = DBConnection.CreateDBConnection();
                string sql = "select * from T_User";
                cmd = new SqlCommand(sql, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Book usr = new Book();
                    usr.BookNo = rd.GetString(0);
                    usr.BookName = rd.GetString(1);
                    usr.Author = rd.GetString(2);
                    usr.Publisher = rd.GetString(3);
                    usr.Format = rd.GetInt32(4);
                    usr.Page = rd.GetInt32(5);
                    usr.Price = Convert.ToSingle(rd.GetValue(6));
                    usr.EnterDate = rd.GetString(7);
                    usr.Borrow = rd.GetString(8);
                    users.Add(usr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return users;

        }


        
    }
}
