namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MONHOC
    {

        public string MAMH { get; set; }

        public string TENMH { get; set; }

        public int SOTIET_LT { get; set; }

        public int SOTIET_TH { get; set; }

       
    }
}
