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
using DAL;
using System.Data.SqlClient;

namespace bigproject
{
    public partial class UserControl_BookIn : UserControl
    {
        
        BookBLL userbll = new BookBLL();
        String _strBookNo;

        private void TestDBConnection()
        {
            try
            {
                SqlConnection con = DBConnection.CreateDBConnection();
                MessageBox.Show("数据库连接测试成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControl_BookIn_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = System.DateTime.Now.ToString();
            txt_bookNo.Text = _strBookNo;
            
        }

        public UserControl_BookIn()
        {
            InitializeComponent();
        }

        public UserControl_BookIn(String _strBookNo)
        {
            InitializeComponent();
            this._strBookNo = _strBookNo;

        }

        private void btn_AddBook_Click(object sender, EventArgs e)
        {
            BookBLL Bookbll = new BookBLL();
            Book book = new Book();
            book.BookNo = _strBookNo;
            book.BookName = txt_bookName.Text.Trim();
            book.Author = txt_author.Text.Trim();
            book.Publisher = txt_publisher.Text.Trim();
            book.Format = Convert.ToInt32(comb_format.Text.Trim());
            book.Page = Convert.ToInt32(txt_page.Text.Trim());
            book.Price = Convert.ToSingle(txt_price.Text.Trim());
            book.EnterDate = dateTimePicker1.Text.Trim();
            book.Borrow = "1";
            try
            {
                int row = Bookbll.AddBook(book);
                if (row > 0)
                    MessageBox.Show("添加信息成功！");
            }
            catch (Exception ex)
            {
                throw ex;
            }   

        }



    }
    
}
