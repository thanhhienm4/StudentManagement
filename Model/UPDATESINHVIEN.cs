using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    class UPDATESINHVIEN
    {
        public string MASV { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public bool PHAI { get; set; }
        public string DIACHI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string MALOP { get; set; }
        public bool DANGHIHOC { get; set; }
        public string PASSWORD { get; set; }

        public UPDATESINHVIEN()
        {

        }
        public UPDATESINHVIEN(SINHVIEN model)
        {
            MASV = model.MASV;
            TEN = model.TEN;
            HO = model.HO;
            MALOP = model.MALOP.Trim();
            PHAI = model.PHAI;
            DIACHI = model.DIACHI;
            NGAYSINH = model.NGAYSINH;
            DANGHIHOC = model.DANGHIHOC;
            PASSWORD = model.PASSWORD;
        }
    }
}
