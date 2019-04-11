using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.IO {
    public class xmlInstrument {

        public static bool SaveData() {
            try {
                XmlHelper.ToXmlFile(myGlobal.multimeterInfo, AppDomain.CurrentDomain.BaseDirectory + "Multimeter.xml");
                XmlHelper.ToXmlFile(myGlobal.switchcardInfo, AppDomain.CurrentDomain.BaseDirectory + "Switchcard.xml");
                XmlHelper.ToXmlFile(myGlobal.powersupplyInfo, AppDomain.CurrentDomain.BaseDirectory + "Powersupply.xml");
                return true;
            } catch {
                return false;
            }
        }

        public static bool LoadData() {
            try {
                myGlobal.multimeterInfo = XmlHelper.FromXmlFile<InstrumentInfo>(AppDomain.CurrentDomain.BaseDirectory + "Multimeter.xml");
                myGlobal.switchcardInfo = XmlHelper.FromXmlFile<InstrumentInfo>(AppDomain.CurrentDomain.BaseDirectory + "Switchcard.xml");
                myGlobal.powersupplyInfo = XmlHelper.FromXmlFile<InstrumentInfo>(AppDomain.CurrentDomain.BaseDirectory + "Powersupply.xml");
                return true;
            }
            catch {
                return false;
            }
        }


    }
}
