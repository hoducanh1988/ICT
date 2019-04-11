using ICT_VNPT.Func.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.Ulti
{
    public class ViewHelper {

        /// <summary>
        /// 
        /// </summary>
        public static void resetTreeIcon() {

            if (myGlobal.duts.Count == 0) return;
            if (myGlobal.duts[0].Cases[0].Items.Count == 0) return;

            foreach (var i in myGlobal.duts[0].Cases[0].Items) {
                i.ItemResult = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void clearDebugWindow() {

            myGlobal.debugLog.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void clearTestResult() {

            myGlobal.resultGridItems.Clear();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void clearStatusBar() {

        }


        /// <summary>
        /// 
        /// </summary>
        public static void clearGoNoGo() {

            myGlobal.goTestInfo.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void clearAll() {

            resetTreeIcon();
            clearDebugWindow();
            clearTestResult();
            clearStatusBar();
            clearGoNoGo();
        }

    }
}
