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
    public partial class DBtable : UserControl
    {
        BookBLL bookbll = new BookBLL();
        Book book = new Book();

        List<Book> users = new List<Book>();
        //User usr = new User();//之所以要定义user对象，是为了编辑用户和删除用户

        public DBtable()
        {
            InitializeComponent();
        }

        private void DBtable_Load(object sender, EventArgs e)
        {
            List<Book> users = bookbll.SearchAllBooks();
            dataGridView1.DataSource = users;

            //DataGridView默认指向第一行
            book.BookNo = dataGridView1.Rows[0].Cells[0].Value.ToString();
            book.BookName = dataGridView1.Rows[0].Cells[1].Value.ToString();
            book.Author = dataGridView1.Rows[0].Cells[2].Value.ToString();
            book.Publisher = dataGridView1.Rows[0].Cells[3].Value.ToString();
            book.Format = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
            book.Page = Convert.ToInt32(dataGridView1.Rows[0].Cells[5].Value);
            book.Price=Convert.ToInt32(dataGridView1.Rows[0].Cells[6].Value);
            //book.EnterDate = dataGridView1.Rows[0].Cells[7].Value.ToString();

        }


    }
}
