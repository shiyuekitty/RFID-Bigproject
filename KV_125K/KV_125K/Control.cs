using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace KV_125K
{
    /// <summary>
    /// 门禁控制器类(成华清 2015/07/26创建)
    /// </summary>
    public class Control
    {
        #region 变量

        private SerialPort serialport = new SerialPort();

        /// <summary>
        /// 是否打开串口
        /// </summary>
        private bool _IsOpen = false;
        private Thread thread;

        public bool IsRead = true;

        #endregion
        #region 属性

        /// <summary>
        /// 是否打开串口
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return _IsOpen;
            }
            set
            {
                _IsOpen = value;
            }
        }

        #endregion

        /// <summary>
        /// 发送数据委托
        /// </summary>
        /// <param name="Data"></param>
        public delegate void DelegateDataSend(string Data);

        /// <summary>
        /// 发送数据事件
        /// </summary>
        public event DelegateDataSend EventDataSend;

        public delegate void DelegateHexData(string Data);

        /// <summary>
        /// 接收十六进制标签
        /// </summary>
        public event DelegateHexData EventHexData;

        public delegate void DelegateDataWG(string Data);

        /// <summary>
        /// 接受韦根数据事件
        /// </summary>
        public event DelegateDataWG EventDataWg;

        public delegate void DelegateData(string Data);
        /// <summary>
        /// 发送数据
        /// </summary>
        public event DelegateData EventData;

        public string OpenPort(string PortName)
        {
            if (this.serialport.IsOpen)
            {
                ClosePort();
            }

            try
            {
                this.serialport = new SerialPort(PortName);
                this.serialport.BaudRate = 9600;
                this.serialport.DataBits = 8;
                this.serialport.StopBits = StopBits.One;
                this.serialport.Parity = Parity.None;
                this.serialport.Open();
                this.IsOpen = true;

                //this.thread = new Thread(new ThreadStart(Receive));
                //this.thread.IsBackground = true;
                //this.thread.Start();
            }
            catch (Exception err)
            {
                return err.Message;
            }

            return "";
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns>空字符串为成功，其他失败</returns>
        public void ClosePort()
        {
            try
            {
                 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        public void Receive()
        {
            try
            {
                while (this.IsOpen)
                {
                    Thread.Sleep(1);
                    if (IsRead)
                    {
                        //读取卡号
                        string Data = RcvFrame();
                        if (Data.Length == 1)
                        {
                            if (EventDataSend != null)
                            {
                                EventDataSend(Data);
                            }
                        }
                        else if (Data.Length == 10 || Data.Length == 9)
                        {
                            Thread.Sleep(1);
                            if (EventDataWg != null)
                            {
                                EventDataWg(Data);
                            }
                        }
                        else if (Data.Length > 10)
                        {
                            Thread.Sleep(1);
                            if (EventData != null)
                            {
                                EventData(Data);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 串口从读写器读取数据
        /// </summary>
        /// <returns></returns>
        private string RcvFrame()
        {
            string str = "";

            if (!this.IsOpen)
            {
                throw new Exception("串口未打开!");
            }

            try
            {
                if (this.serialport.BytesToRead > 0)
                {
                    //从串口中读取数据
                    str = this.serialport.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return str;
        }

        /// <summary>
        /// 串口向读写器发送命令
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>
        private void SendAFrame(string Command)
        {
            if (!this.IsOpen)
            {
                throw new Exception("串口未打开！");
            }

            try
            {
                this.serialport.DiscardInBuffer();
                this.serialport.WriteLine(Command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将卡号写入到门禁控制器中
        /// </summary>
        /// <param name="ID"></param>
        public void InsertID(string ID)
        {
            try
            {
                string data = "1:" + ID;
                SendAFrame(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将卡号从门禁控制器中删除
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteID(string ID)
        {
            try
            {
                string data = "2:" + ID;
                SendAFrame(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取全部卡号
        /// </summary>
        /// <returns></returns>
        public string[] GetAllID()
        {
            string data = "3:";
            string[] ID = null;

            SendAFrame(data);

            Thread.Sleep(1);
            string Data = RcvFrame();

            ID = Data.Split('-');

            return ID;

        }

        /// <summary>
        /// 获取全部开门记录
        /// </summary>
        /// <returns></returns>
        public string[] GetAllRecorf()
        {
            string data = "4:";
            string[] ID = null;

            SendAFrame(data);

            Thread.Sleep(1);
            string Data = RcvFrame();

            ID = Data.Split('-');

            return ID;

        }
    }
}
