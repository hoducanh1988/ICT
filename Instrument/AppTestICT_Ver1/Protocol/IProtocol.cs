using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol {
    public interface IProtocol {

        bool Open();
        bool Open(string visaaddress);
        bool Open(string portname, string baudrate, string databits, Parity parity, StopBits stopbits);
        bool Open(string ip, string portnumber, string user, string password);
        bool IsConnected();
        bool Write(string cmd);
        bool WriteLine(string cmd);
        string Query(string cmd);
        string Read();
        bool Close();
    }
}
