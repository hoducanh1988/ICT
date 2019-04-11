﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.Func.IO {

    public class LogTotal : AbstractLogger {

        private string _dir_Log_Total = "";
        private string _file_Name = "";


        /// <summary>
        /// 
        /// </summary>
        public LogTotal() : base() {
            _dir_Log_Total = Path.Combine(base.dir_Jig_Index, "LogTotal");
            if (!Directory.Exists(_dir_Log_Total)) Directory.CreateDirectory(_dir_Log_Total);
            //get file name
            this._file_Name = string.Format("{0}_{1}_Jig{2}_{3}.csv", 
                Properties.Settings.Default.ScriptName,
                "ICT",
                myGlobal.settingInfo.JigIndex, 
                DateTime.Now.ToString("yyyyMMdd"));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logInfo"></param>
        /// <param name="moreInfo"></param>
        /// <returns></returns>
        public bool To_CSV_File(VnptLogMoreInfo moreInfo) {
            try {
                string title = "DATE_TIME,WORK_ORDER,OPERATOR,PN,UID1,UID2,TESTNAME,L_LIMIT,U_LIMIT,MEASURE_VAL,RESULT,INFO1,INFO2,INFO3,INFO4,INFO5,INFO6,INFO7,INFO8,INFO9,INFO10";
                string fileFullName = Path.Combine(_dir_Log_Total, _file_Name);
                bool IsCreateTitle = !File.Exists(fileFullName);

                //write data to file
                using (StreamWriter sw = new StreamWriter(fileFullName, true, Encoding.Unicode)) {
                    //write title
                    if (IsCreateTitle == true) sw.WriteLine(title);

                    foreach (PropertyInfo propertyInfo in logInfo.GetType().GetProperties()) {
                        if (propertyInfo.PropertyType == typeof(VnptTestItemInfo)) {
                            VnptTestItemInfo itemInfo = (VnptTestItemInfo)propertyInfo.GetValue(logInfo, null);

                         
                            //save log
                            string content = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                                                           DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ffff"),
                                                           logInfo.Production_Command.Replace(",", ";"),
                                                           logInfo.Operator.Replace(",", ";"),
                                                           logInfo.ProductCode.Replace(",", ";"),
                                                           logInfo.Mac_Address.Replace(":", "").ToUpper().Replace(",", ";"),
                                                           logInfo.Product_Serial.Replace(",", ";"),
                                                           propertyInfo.Name.Replace(",", ";"),
                                                           itemInfo.Lower_Limit.Replace(",", ";"),
                                                           itemInfo.Upper_Limit.Replace(",", ";"),
                                                           itemInfo.Actual_Value.Replace(",", ";"),
                                                           itemInfo.Result.Replace(",", ";"),
                                                           moreInfo.Info1,
                                                           moreInfo.Info2,
                                                           moreInfo.Info3,
                                                           moreInfo.Info4,
                                                           moreInfo.Info5,
                                                           moreInfo.Info6,
                                                           moreInfo.Info7,
                                                           moreInfo.Info8,
                                                           moreInfo.Info9,
                                                           moreInfo.Info10
                                                           );

                            //write content
                            sw.WriteLine(content);
                        }
                    }
                }
                return true;
            }
            catch {
                return false;
            }
        }

    }
}