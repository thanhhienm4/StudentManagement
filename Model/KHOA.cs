namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class KHOA
    {
        
        public string MAKHOA { get; set; }

        public string TENKHOA { get; set; }

    }
}
