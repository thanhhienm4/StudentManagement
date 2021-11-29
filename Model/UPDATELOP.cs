using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    class UPDATELOP
    {
        public string MALOP { get; set; }
        public string TENLOP { get; set; }
        public string KHOAHOC { get; set; }
        public string MAKHOA { get; set; }

        public UPDATELOP()
        {

        }
        public UPDATELOP(LOP model)
        {
            MALOP = model.MALOP;
            TENLOP = model.TENLOP;
            KHOAHOC = model.KHOAHOC;
            MAKHOA = "VT_CNTT";
        }
    }
}
