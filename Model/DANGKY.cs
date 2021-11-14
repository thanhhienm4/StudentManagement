namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANGKY")]
    public partial class DANGKY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALTC { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MASV { get; set; }

        public int? DIEM_CC { get; set; }

        public double? DIEM_GK { get; set; }

        public double? DIEM_CK { get; set; }

        public bool? HUYDANGKY { get; set; }

        public Guid rowguid { get; set; }

        public virtual LOPTINCHI LOPTINCHI { get; set; }
    }
}
