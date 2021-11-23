using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public class UpdateGrade
    {
        public int MALTC { get; set; }

        public string MASV { get; set; }

        public int? DIEM_CC { get; set; }

        public double? DIEM_GK { get; set; }

        public double? DIEM_CK { get; set; }
        public UpdateGrade(DANGKY model)
        {
            this.DIEM_CC = model.DIEM_CC;
            this.DIEM_CK = model.DIEM_CK;
            this.DIEM_GK = model.DIEM_GK;
            this.MALTC = model.MALTC;
            this.MASV = model.MASV;
        }

    }
}
