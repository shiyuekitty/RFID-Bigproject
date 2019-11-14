using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KV_ISO15693;
using BLL;
using Model;
using System.Threading;
using KV_125K;

namespace bigproject
{
    
    public partial class Form1 : Form
    {

        string strID;
        string BookNo;
        string BookName;
        string strBookNo;
        bool IsOpen_125k;
        string strWGData;
        private Thread thread_125k;
        private SerialPort serialPort;
        Panel panel = new Panel();
        KV_ISO15693.Reader read = new KV_ISO15693.Reader();
        private KV_125K.Reader reader = new KV_125K.Reader();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 15693卡打开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text == "打开")
            {
                String PortName = cmbportID.Text.Trim();
                int BaudRate = Convert.ToInt32(txtBuand.Text.Trim());
                Byte value = read.OpenSerialPort(PortName, BaudRate);
                String[] TagNumber = new String[1];
                int TagCount = 0;
                if (value == 0x00)
                {
                    MessageBox.Show("15693串口打开成功！");        
                    value = read.Inventory(ModulateMethod.ASK, InventoryModel.Single, ref TagCount, ref TagNumber);
                    if (value == 0x00)
                    {
                        BookNo = TagNumber[0];
                    }
                }
                else
                {
                    MessageBox.Show("15693串口打开失败！");
                    MessageBox.Show("15693串口打开失败！");
                }
            }
        }
        /// <summary>
        /// 125K卡打开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_People_Click(object sender, EventArgs e)
        {
            if (reader.OpenPort(comboBox1.Text, Convert.ToInt32(textBox1.Text)) == "")
            {
                MessageBox.Show("125K串口打开成功!");
            }
            else
            {
                MessageBox.Show("125K的串口打开失败!");
            }
        }
        /// <summary>
        /// 主界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 获取应用程序集的基目录
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith("\\bin\\Debug\\") || dataDir.EndsWith("\\bin\\Release\\"))
            {
                // 获取基目录的上一级目录的全路径
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                //设置当前应用程序集的"DataDirectory"为dataDir的值, DataDirectory 是表示数据库路径的替换字符串
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            string[] portID = SerialPort.GetPortNames();
            if (portID.Length < 0)
            {
                MessageBox.Show("系统没有可用串口！");
            }
            else
            {
                comboBox1.Items.AddRange(portID);
                cmbportID.Items.AddRange(portID);
                comboBox1.SelectedIndex = 0;
                cmbportID.SelectedIndex = 0;
                textBox1.Text = "9600";
                txtBuand.Text = "115200";
            }
        }
        /// <summary>
        /// 书籍入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddBook_Click(object sender, EventArgs e)
        {
            UserControl_BookIn fb = new UserControl_BookIn(BookNo);
            splitContainer1.Panel2.Controls.Clear();//清理Panel2里的所有内容
            splitContainer1.Panel2.Controls.Add(fb);//加载控件到Panel2
        }
        /// <summary>
        /// 按书号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            txt_MessageShow.Clear();
            BookBLL bookbll = new BookBLL();
            Book book = new Book();
            book = bookbll.SearchByBookNo(BookNo);
            textBox3.Text = book.BookNo;
            if (textBox3.Text == book.BookNo)
            {
                txt_MessageShow.Text = "Name: " + book.BookName + " \t\t" + " Author:" + book.Author + " \t\t Publisher: " + book.Publisher + " \t\tFormat:" + book.Format + " \t\t\t Page:" + book.Page + " \t\t\t\t\tPrice:" + book.Price + " \t\t EnterDate:" + book.EnterDate;
            }
            else
            {
                MessageBox.Show("not found!");
            }
            
            
        }
        /// <summary>
        /// 按书名查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            txt_MessageShow.Clear();
            BookBLL bookbll = new BookBLL();
            Book book = new Book();
            book = bookbll.SearchBookName(BookName);
            textBox3.Text = book.BookName;
            txt_MessageShow.Text = "Name: " + book.BookName + " \t\t" + " Author:" + book.Author + " \t\t Publisher: " + book.Publisher + " \t\tFormat:" + book.Format + " \t\t\t Page:" + book.Page + " \t\t Price:" + book.Price + " \t\t EnterDate:" + book.EnterDate;
        }
        /// <summary>
        /// 查看整个书库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            DBtable t = new DBtable();
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(t);

        }
        /// <summary>
        /// 借阅/归还
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            User_borrow_return bo = new User_borrow_return(BookNo);
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(bo);
        }


     /// <summary>
     /// 来访记录
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>

        void reader_eventWG(string data)
        {
            strID = data;
            MessageBox.Show(data);
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            UserControl_PList pl = new UserControl_PList(strID);
            reader_eventWG(strID);
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(pl);
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {

            UserControl_Delete de = new UserControl_Delete(BookNo);
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(de);
        }
    }
}
