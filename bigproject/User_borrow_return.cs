using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace bigproject
{
    public partial class User_borrow_return : UserControl
    {
        string BookNo;
        BookBLL bookbll = new BookBLL();
        Book book = new Book();
        public User_borrow_return()
        {
            InitializeComponent();
        }
        public User_borrow_return(string No)
        {
            InitializeComponent();
            BookNo = No;
        }

        /// <summary>
        /// 借阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_borrow_Click(object sender, EventArgs e)
        {
            int row;
            if (book.Borrow == "1")
            {
                book.Borrow = "2";
                row = bookbll.UpdateBook(book);
                if (row > 0)
                {
                    MessageBox.Show("借阅成功！");
                    txt_borrow.Text = "已借出";

                }

            }
            else if (book.Borrow == "2")
            {
                MessageBox.Show("已经借出！");
            }
            else
            {
                MessageBox.Show("尚未入库！");
            }
        }

        private void User_borrow_return_Load(object sender, EventArgs e)
        {
            book = bookbll.SearchByBookNo(BookNo);
            txt_bookNo.Text = book.BookNo;
            txt_bookName.Text = book.BookName;
            txt_author.Text = book.Author;
            txt_publisher.Text = book.Publisher;
            comb_format.Text = Convert.ToString(book.Format);
            txt_page.Text = Convert.ToString(book.Page);
            txt_price.Text = Convert.ToString(book.Price);
            dateTimePicker1.Text = book.EnterDate;
            if (book.Borrow == "1")
            {
                txt_borrow.Text = "可借阅";
            }
            else if (book.Borrow == "2")
            {
                txt_borrow.Text = "已借出";
            }
            else
            {
                txt_borrow.Text = "书籍不存在";
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            int row;
            if (book.Borrow == "2")
            {
                book.Borrow = "1";
                row = bookbll.UpdateBook(book);
                if (row > 0)
                {
                    MessageBox.Show("归还成功！");
                    txt_borrow.Text = "可借阅";

                }

            }
            else if (book.Borrow == "1")
            {
                MessageBox.Show("尚未借出！");
            }
            else if (book.Borrow == "0")
            {
                MessageBox.Show("尚未入库！");
            }
        }
    }
}
