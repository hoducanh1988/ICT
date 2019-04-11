using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment {
    public interface IPowerSupply : IEquipment {

        //Commond
        int Preset();
        int set_Output_State(bool flag);
        string get_Output_State();
        int set_Voltage_Range(double value);
        string get_Voltage_Range();
        int set_Trigger_Delay(double value);
        string get_Trigger_Delay();
        int set_Output_Value(double volt, double current);
        string get_Output_Value();

        //Current
        int set_Current_Protection_State(bool flag);
        string get_Current_Protection_State();
        int set_Current_Protection_Level(double value);
        string get_Current_Protection_Level();
        int clear_Current_Protection_Flag();
        string get_Current_Protection_Flag();
        int set_Current_Step(double value);
        string get_Current_Step();
        string get_Current_Limit_Value();
        string get_Current_Actual_Value();

        //Voltage
        int set_Voltage_Protection_State(bool flag);
        string get_Voltage_Protection_State();
        int set_Voltage_Protection_Level(double value);
        string get_Voltage_Protection_Level();
        int clear_Voltage_Protection_Flag();
        string get_Voltage_Protection_Flag();
        int set_Voltage_Step(double value);
        string get_Voltage_Step();
        string get_Voltage_Limit_Value();
        string get_Voltage_Actual_Value();

    }
}
