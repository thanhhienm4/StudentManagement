namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DONGHOCPHI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MASV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(9)]
        public string NIENKHOA { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HOCKY { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime NGAYDONG { get; set; }

        public int SOTIENDONG { get; set; }

        public virtual HOCPHI HOCPHI { get; set; }
    }
}
