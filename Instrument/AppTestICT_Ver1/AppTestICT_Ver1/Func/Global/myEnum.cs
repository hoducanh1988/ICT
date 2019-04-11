using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestICT_Ver1.Func.Global {

    public enum ConnectionType {

        UART = 0,
        TELNET = 1,
        SCPI = 2,
        DRIVER = 3
    };

    public enum InstrumentType {
        Meter = 0,
        Power = 1,
        Switcher = 2
    }

    public enum FlagError {

    }

}
