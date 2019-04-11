using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.IO {

    public class iniRange {


        public static Dictionary<string, string> FromIniFile(string equipment_name, string mode) {
            try {
                string file = string.Format("{0}Reference\\{1}\\confRange\\{2}.ini", AppDomain.CurrentDomain.BaseDirectory, equipment_name, mode);
                if (!File.Exists(file)) return null;

                Dictionary<string, string> dict = new Dictionary<string, string>();

                StreamReader sr = new StreamReader(file);
                //read test item
                while (sr.Peek() != -1) {
                    string data = sr.ReadLine();
                    if (string.IsNullOrEmpty(data)) continue;

                    string[] buffer = data.Split(',');
                    dict.Add(buffer[0], buffer[1]);
                }

                sr.Close();

                return dict;
            }
            catch {
                return null;
            }
        }


    }
}
