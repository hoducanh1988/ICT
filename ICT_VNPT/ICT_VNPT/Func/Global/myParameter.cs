using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.Global
{
    public class myParameter
    {
        static myParameter() {

            banks = new List<string>();
            for (int i = 1; i <= 32; i++) { banks.Add(i.ToString()); }

            measuretimes = new List<string>();
            for (int i = 1; i <= 10; i++) { measuretimes.Add(i.ToString()); }

            retrytimes = new List<string>();
            for (int i = 1; i <= 10; i++) { retrytimes.Add(i.ToString()); }
        }

        //Instrument content
        public static List<string> connectionTypes = new List<string>() { "UART", "TELNET", "SCPI", "DRIVER" };
        public static List<string> serialports = new List<string>();
        public static List<string> baudRates = new List<string>() { "75", "110", "134", "150", "300", "600", "1200", "1800", "2400", "4800", "7200", "9600", "14400", "19200", "38400", "57600", "115200", "128000", "256000" };
        public static List<string> dataBits = new List<string>() { "4", "5", "6", "7", "8" };
        public static List<string> paritys = new List<string>() { "Even", "Odd", "None", "Mark", "Space" };
        public static List<string> stopBits = new List<string>() { "1", "1.5", "2" };

        //Tree Test Setting
        public static List<string> booleans = new List<string>() { "True", "False" };
        public static List<string> testunits = new List<string>() { "R", "D", "V", "A", "Co", "Ca" };
        public static List<string> banks = null;
        public static List<string> measuretimes = null;
        public static List<string> retrytimes = null;

        public static Dictionary<string, string> dictUOM = new Dictionary<string, string>() {
            { "R", "\u2126" },
            { "D", "V" },
            { "V", "V" },
            { "A", "A" },
            { "Co", "\u2126" },
            { "Ca", "F" },
            //{ "L", "\u2126" }
        };

        public static List<string> triggersources = new List<string>() { "IMM", "BUS" };


        //Edit configurations
        public static List<string> testCaseErrorOptions = new List<string>() {
            "Stop",
            "Continue"
        };
        public static List<string> yesNoOptions = new List<string>() {
            "Yes",
            "No"
        };
        public static List<string> resultLogFormats = new List<string>() {
            "*.CSV",
            "*.XML"
        };
        public static List<string> unittypes = new List<string>() {
            "p",
            "n",
            "u",
            "m",
            "-",
            "k",
            "M",
            "G",
            "T",
            "P",
            "E",
            "Z",
            "Y"
        };

        public static Dictionary<string, string> dictRangeResistance = null;
        public static Dictionary<string, string> dictRangeCapacitance = null;
        public static Dictionary<string, string> dictRangeDCVoltage = null;
        public static Dictionary<string, string> dictRangeDCCurrent = null;


        public static Dictionary<string, string> dictGuide = new Dictionary<string, string>() {
            {
                "itemname",
                "<Test Item Name>\n" +
                "Là tên linh kiện hoặc tên khối linh kiện cần kiểm tra."
            },
            {
                "itemunit",
                "<Test Item Unit>\n" +
                "Là phương pháp kiểm tra linh kiện: " +
                "R= điện trở, " +
                "D= diode, " +
                "V= điện áp, " +
                "A= dòng điện, " +
                "Co= thông dẫn, " +
                "Ca= tụ điện, " +
                "L= cuộn cảm."
            },
            {
                "unittype",
                "<Unit Type>\n" +
                "Là hệ số đơn vị đo lường " +
                "p= picô, " +
                "n= nanô, " +
                "u= micrô, " +
                "m= mili, " +
                "-= hệ 10, " +
                "k= kilô, " +
                "M= Mêga, " +
                "G= Giga, " +
                "T= Têra, " +
                "P= Pêta, " +
                "E= Êxa, " +
                "Z= Zêta, " +
                "Y= Yôta."
            },
            {
                "ispower",
                "<Is Power>\n" +
                "Là cờ xác nhận việc có hay không cấp nguồn cho sản phẩm trước khi kiểm tra linh kiện / khối linh kiện này, " +
                "True = có, False = không."
            },
            {
                "ischeck",
                "<Is Check>\n" +
                "Là cờ xác nhận việc có hay bỏ qua kiểm tra linh kiện / khối linh kiện này, " +
                "True = có kiểm tra, False = bỏ qua."
            },


            {
                "bank1",
                "<Bank1>\n" +
                "Là chỉ số của channel Bank1 của switch card cần close với chân COM của Bank1, " +
                "Giá trị trong dải 1,2,3...32."
            },
            {
                "bank2",
                "<Bank2>\n" +
                "Là chỉ số của channel Bank2 của switch card cần close với chân COM của Bank2, " +
                "Giá trị trong dải 1,2,3...32."
            },
            {
                "upperlimit",
                "<Upper Value>\n" +
                "Là giá trị giới hạn trên của ngưỡng giới hạn. Nếu vượt qua giá trị này thì linh kiện là không đạt yêu cầu. Giá trị -1 nghĩa là vô cùng."
            },
            {
                "lowerlimit",
                "<Lower Value>\n" +
                "Là giá trị giới hạn dưới của ngưỡng giới hạn. Nếu không vượt qua giá trị này thì linh kiện là không đạt yêu cầu."
            },
            {
                "measuretime",
                "<Measure Time>\n" +
                "Là số lần đọc kết quả từ máy đo trong 1 lần kiểm tra, giá trị trả về cuối cùng là giá trị trung bình."
            },
            {
                "retrytime",
                "<Retry Time>\n" +
                "Là số lần test lại nếu giá trị đo được bị vượt ngưỡng giới hạn."
            },
            {
                "waittime",
                "<Wait Time>\n" +
                "Là thời gian trễ sau 1 khoảng thời gian mới thực hiện test item. Đơn vị là mili senconds."
            },

            {
                "goodmessage",
                "<Pass Message>\n" +
                "Là text message hiển thị khi kết quả kiểm tra linh kiện / khối linh kiện là PASS."
            },
            {
                "errormessage",
                "<Fail Message>\n" +
                "Là text message hiển thị khi kết quả kiểm tra linh kiện / khối linh kiện là FAIL."
            },
            
        };

    }
}
