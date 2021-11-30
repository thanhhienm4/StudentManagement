namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOP")]
    public partial class LOP
    {
        [Key]
        [StringLength(10)]
        public string MALOP { get; set; }

        [Required]
        [StringLength(50)]
        public string TENLOP { get; set; }

        [Required]
        [StringLength(9)]
        public string KHOAHOC { get; set; }

        [Required]
        [StringLength(10)]
        public string MAKHOA { get; set; }

        public Guid rowguid { get; set; }

    }
}
