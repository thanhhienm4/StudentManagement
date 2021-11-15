namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIANGVIEN")]
    public partial class GIANGVIEN
    {
        public GIANGVIEN()
        {
            HOTEN = HO + " " + TEN;
        }

        [Key]
        [StringLength(10)]
        public string MAGV { get; set; }

        [Required]
        [StringLength(10)]
        public string MAKHOA { get; set; }

        [StringLength(50)]
        public string HO { get; set; }

        [StringLength(10)]
        public string TEN { get; set; }

        [StringLength(20)]
        public string HOCVI { get; set; }

        [StringLength(20)]
        public string HOCHAM { get; set; }

        [StringLength(50)]
        public string CHUYENMON { get; set; }

        public string HOTEN { get; set; }


       
    }
}
