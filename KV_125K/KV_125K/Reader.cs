using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace KV_125K
{
    /// <summary>
    /// 王子玉 20140822 创建
    /// </summary>
    public class Reader
    {
        #region 变量

        /// <summary>
        /// 串口对象
        /// </summary>
        public SerialPort serialport = new SerialPort();
        private bool isOpen = false;
        private Thread thread;
        
        #endregion


        #region 属性
        
        #endregion


        #region 事件&委托

        public delegate void DelegateDataSend(string data);

        /// <summary>
        /// 接收Hex数据事件
        /// </summary>
        public event DelegateDataSend eventHex;

        /// <summary>
        /// 接收韦根数据事件
        /// </summary>
        public event DelegateDataSend eventWG;

        public delegate void DelegateZero();

        /// <summary>
        /// 接收全零数据事件
        /// </summary>
        public event DelegateZero eventZero;

        #endregion


        #region 私有方法


        
        #endregion


        #region 公有方法

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="PortName">串口号</param>
        /// <param name="BaudRate">波特率，最佳9600</param>
        /// <returns>空字符串为成功，其他失败</returns>
        public string OpenPort(string PortName, int BaudRate)
        {
            if (this.serialport.IsOpen == true)
            {
                this.isOpen = true;
                this.serialport.DiscardInBuffer();

                this.thread = new Thread(new ThreadStart(Receive));
                this.thread.IsBackground = true;
                this.thread.Start();

                return "";
            }

            try
            {
                this.serialport = new SerialPort(PortName);
                this.serialport.BaudRate = BaudRate;
                this.serialport.DataBits = 8;
                this.serialport.StopBits = StopBits.One;
                this.serialport.Parity = Parity.None;
                this.serialport.Open();
                this.isOpen = true;

                this.thread = new Thread(new ThreadStart(Receive));
                this.thread.IsBackground = true;
                this.thread.Start();
            }
            catch (Exception err)
            {
                return err.Message;
            }

            return "";
        }

        /// <summary>
        /// 停止串口
        /// </summary>
        /// <returns>空字符串为成功，其他失败</returns>
        public string StopPort()
        {
            this.isOpen = false;

            return "";
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClosePort()
        {
            StopPort();
            this.serialport.Close();
        }

        /// <summary>
        /// 接收一次数据
        /// </summary>
        public void Receive()
        {
            try
            {
                while (this.isOpen)
                {
                    byte[] receiveData = new byte[5];
                    while (this.serialport.BytesToRead > 4)
                    {
                        int count = this.serialport.Read(receiveData, 0, receiveData.Length);
                        String time = System.DateTime.Now.ToLongTimeString();
                        if (count == 5)
                        {
                            string str = "";
                            for (int i = 0; i < 5; i++)
                            { str += string.Format("{0:X2}", receiveData[i]); }
                            string strHex = str;
                            if (this.eventHex != null)
                            {
                                this.eventHex(strHex);
                            }

                            string strWG = string.Format("{0:D3},{1:D5}", receiveData[1], receiveData[2] * 256 + receiveData[3]);
                            if (this.eventWG != null)
                            {
                                this.eventWG(strWG);
                            }

                            int sum = receiveData[0] + receiveData[1] + receiveData[2] + receiveData[3] + receiveData[4];
                            if (sum == 0)
                            {
                                if (this.eventZero != null)
                                {
                                    this.eventZero();
                                }
                            }
                        }
                        Thread.Sleep(20);
                    }

                    Thread.Sleep(20);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        
        #endregion
    }
}
