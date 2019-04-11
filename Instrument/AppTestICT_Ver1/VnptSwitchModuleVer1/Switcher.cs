using Equipment;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace VnptSwitchModuleVer1
{
    public class Switcher : ISwitcher {

        /*******************************************************/
        SerialPort serialport = null;

        /// <summary>
        /// 
        /// </summary>
        public bool IsConnected {
            get {
                return this.serialport != null ? this.serialport.IsOpen : false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Close() {
            try {
                if (IsConnected == true) {
                    this.serialport.Close();
                    return true;
                } else return true;
            } catch {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Open() {
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="visaaddress"></param>
        /// <returns></returns>
        public bool Open(string visaaddress) {
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="portname"></param>
        /// <param name="baudrate"></param>
        /// <param name="databits"></param>
        /// <param name="parity"></param>
        /// <param name="stopbits"></param>
        /// <returns></returns>
        public bool Open(string portname, string baudrate, string databits, Parity parity, StopBits stopbits) {
            try {
                if (this.serialport == null || this.serialport.IsOpen == false) {
                    this.serialport = new SerialPort();

                    this.serialport.PortName = portname;
                    this.serialport.BaudRate = int.Parse(baudrate);
                    this.serialport.DataBits = int.Parse(databits);
                    this.serialport.Parity = parity;
                    this.serialport.StopBits = stopbits;

                    this.serialport.Open();
                }
                return this.serialport.IsOpen;
            } catch {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="portnumber"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Open(string ip, string portnumber, string user, string password) {
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Set_Card_Open() {
            if (!IsConnected) return 1;
            return send_command("$00,00#");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <returns></returns>
        public int Set_Bank_Open(int Bank) {
            if (!IsConnected) return 1;

            string cmd = Bank == 1 ? "$00,--#" : "$--,00#";
            return send_command(cmd);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public int Set_Channel_Open(int Bank, int Channel) {
            return Set_Bank_Open(Bank);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public int Set_Channel_Close(int Bank, int Channel) {
            if (!IsConnected) return 1;

            string ch = Channel < 10 ? string.Format("0{0}", Channel) : Channel.ToString();
            string cmd = Bank == 1 ? string.Format("${0},--#", ch) : string.Format("$--,{0}#", ch);
            return send_command(cmd);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="BankStart"></param>
        /// <param name="Channel1"></param>
        /// <param name="Channel2"></param>
        /// <returns></returns>
        public int Set_Channel_Close(int BankStart, int Channel1, int Channel2) {
            if (!IsConnected) return 1;

            string ch1 = Channel1 < 10 ? string.Format("0{0}", Channel1) : Channel1.ToString();
            string ch2 = Channel2 < 10 ? string.Format("0{0}", Channel2) : Channel2.ToString();
            return send_command(string.Format("${0},{1}#", ch1, ch2));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public int Get_Channel_State(int Bank, int Channel) {
            return 0;
        }


        /// <summary>
        /// 0 = success
        /// </summary>
        /// <returns></returns>
        int send_command(string cmd) {
            if (!IsConnected) return 1;
            try {
                //read data from buffer
                this.serialport.ReadExisting();
                
                //write command line
                this.serialport.WriteLine(cmd);
                Thread.Sleep(100);

                //get feedback data
                string data = this.serialport.ReadExisting();

                //return 
                return data.ToLower().Contains("ok") == true ? 0 : 1;
            } catch {
                return -1;
            }
        }

    }
}
