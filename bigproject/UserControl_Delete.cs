using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;
using KV_ISO15693;

namespace bigproject
{
    public partial class UserControl_Delete : UserControl
    {
        string BookNo;
        BookBLL bookbll = new BookBLL();
        Book book = new Book();

        public UserControl_Delete()
        {
            InitializeComponent();
        }

        public UserControl_Delete(string No)
        {
            InitializeComponent();
            BookNo = No;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int row;
            row=bookbll.DeleteBook(BookNo);
            if (row > 0)
            {
                MessageBox.Show("删除成功！");
            }
        }

        private void UserControl_Delete_Load(object sender, EventArgs e)
        {
            book = bookbll.SearchByBookNo(BookNo);
            txt_bookNo.Text = book.BookNo;
            txt_bookName.Text = book.BookName;
            txt_author.Text = book.Author;
            txt_publisher.Text = book.Publisher;
            comb_format.Text=Convert.ToString(book.Format);
            txt_page.Text=Convert.ToString(book.Page);
            txt_price.Text=Convert.ToString(book.Price);
            dateTimePicker1.Text = book.EnterDate;
            if (book.Borrow == "1")
            {
                txt_Borrow.Text = "可借阅";
            }
            else if (book.Borrow == "2")
            {
                txt_Borrow.Text = "已借出";
            }
            else if (book.Borrow == "0")
            {
                txt_Borrow.Text = "查无此书";
            }
        }
    }
}
