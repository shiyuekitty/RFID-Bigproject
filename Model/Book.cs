using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Book
    {
        #region 字段
        private string _BookNO;
        private string _BookName;
        private string _Author;
        private string _Publisher;
        private int _Format;
        private int _Page;
        private float _Price;
        private string _EnterDate;
        private string _Borrow;
        #endregion

        #region 属性
        public string BookNo
        {
            get { return _BookNO; }
            set { _BookNO = value; }
        }
        public string BookName
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public string Publisher
        {
            get;
            set;
        }
        public int Format
        {
            get;
            set;
        }
        public int Page
        {
            get;
            set;
        }
        public float Price
        {
            get;
            set;
        }
        public string EnterDate
        {
            get;
            set;
        }
        public string Borrow
        {
            get;
            set;
        }
        #endregion
    }
}
