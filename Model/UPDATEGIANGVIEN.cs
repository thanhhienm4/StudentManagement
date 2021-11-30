using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    class UPDATEGIANGVIEN
    {
        public string MAGV { get; set; }
        public string MAKHOA { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public string HOCVI { get; set; }
        public string HOCHAM { get; set; }
        public string CHUYENMON { get; set; }
        public UPDATEGIANGVIEN()
        {

        }
        public UPDATEGIANGVIEN(GIANGVIEN model)
        {
            MAGV = model.MAGV;
            MAKHOA = model.MAKHOA.Trim();
            TEN = model.TEN;
            HO = model.HO;
            HOCVI = model.HOCVI;
            HOCHAM = model.HOCHAM;
            CHUYENMON = model.CHUYENMON;
        }
    }
}
