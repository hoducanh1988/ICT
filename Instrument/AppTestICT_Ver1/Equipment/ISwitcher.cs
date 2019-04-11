using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment {
    public interface ISwitcher : IEquipment {

        //Giá trị hàm trả về -------------------//
        // 0 = success
        // 1 = error switcher
        //-1 = error software

        int Set_Card_Open();
        int Set_Bank_Open(int Bank);
        int Set_Channel_Open(int Bank, int Channel);
        int Set_Channel_Close(int Bank, int Channel);
        int Set_Channel_Close(int BankStart, int Channel1, int Channel2);
        int Get_Channel_State(int Bank, int Channel);
    }
}
