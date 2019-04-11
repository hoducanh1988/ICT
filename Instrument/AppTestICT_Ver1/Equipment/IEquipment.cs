using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Equipment
{
    public interface IEquipment
    {
        bool IsConnected { get; }

        bool Open();
        bool Open(string visaaddress);
        bool Open(string portname, string baudrate, string databits, Parity parity, StopBits stopbits);
        bool Open(string ip, string portnumber, string user, string password);
        bool Close();
    }
}
