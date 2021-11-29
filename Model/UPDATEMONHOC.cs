using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    class UPDATEMONHOC
    {
        public string MAMH { get; set; }
        public string TENMH { get; set; }
        public int SOTIET_LT { get; set; }
        public int SOTIET_TH { get; set; }
        public UPDATEMONHOC()
        {

        }
        public UPDATEMONHOC(MONHOC model)
        {
            MAMH = model.MAMH;
            TENMH = model.TENMH;
            SOTIET_LT = model.SOTIET_LT;
            SOTIET_TH = model.SOTIET_TH;
        }
    }
}
