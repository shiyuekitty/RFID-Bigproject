using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KV_125K;

namespace bigproject
{
    public partial class UserControl_PList : UserControl
    {
        string _str;
        private Reader reader = new Reader();
        public UserControl_PList(String str)
        {
            InitializeComponent();
            _str = str;
        }
        void reader_eventWG(String data)
        {
            data = _str;
            listBox.Items.Add(data);
        }
        private void UserControl_PList_Load(object sender, EventArgs e)
        {
            reader.eventWG += reader_eventWG;
        }
    }
}
