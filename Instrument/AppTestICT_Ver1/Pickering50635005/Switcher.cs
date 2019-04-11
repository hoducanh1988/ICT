using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pickering.Pipx40.Interop;

using Equipment;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;

namespace Pickering50635005
{
    public class Switcher : ISwitcher {

        /*******************************************************/
        int card = 0, status = 1;
        StringBuilder cardid = new StringBuilder(100);


        /// <summary>
        /// 
        /// </summary>
        public bool IsConnected {
            get {
                return status == 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Close() {
            try {
                if (IsConnected == true) {
                    status = Pipx40Module.Close(card);
                    return status == 0 ? true : false;
                }
                else return true;
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
            try {
                status = Pipx40Module.Init(visaaddress, 0, 0, ref card);
                if (status == 0) status = Pipx40Module.GetCardId(card, cardid); //get the card's ID 
                return status == 0 ? true : false;
            } catch {
                return false;
            }
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
            return false;
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
            if (status != 0) return 1;
            return Pipx40Module.ClearCard(card);
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <returns></returns>
        public int Set_Bank_Open(int Bank) {
            if (status != 0) return 1;
            return Pipx40Module.ClearSub(card, Bank);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public int Set_Channel_Open(int Bank, int Channel) {
            if (status != 0) return 1;
            return Pipx40Module.SetChannelState(card, Bank, Channel, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public int Set_Channel_Close(int Bank, int Channel) {
            if (status != 0) return 1;
            return Pipx40Module.SetChannelState(card, Bank, Channel, 1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="BankStart"></param>
        /// <param name="Channel1"></param>
        /// <param name="Channel2"></param>
        /// <returns></returns>
        public int Set_Channel_Close(int BankStart, int Channel1, int Channel2) {
            if (status != 0) return 1;

            int s = 0;
            //close specified channel and com in bank1
            s += Set_Bank_Open(BankStart);
            s += Set_Channel_Close(BankStart, Channel1);

            //close specified channel and com in bank2
            s += Set_Bank_Open(BankStart + 1);
            s += Set_Channel_Close(BankStart + 1, Channel2);

            return s;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public int Get_Channel_State(int Bank, int Channel) {
            if (status != 0) return 0;
            short state = -1;
            Pipx40Module.GetChannelState(card, Bank, Channel, ref state);
            return state;
        }
        
    }
}
