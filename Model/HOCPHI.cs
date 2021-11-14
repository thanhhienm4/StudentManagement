namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCPHI")]
    public partial class HOCPHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCPHI()
        {
            CT_DONGHOCPHI = new HashSet<CT_DONGHOCPHI>();
        }

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

        [Column("HOCPHI")]
        public int HOCPHI1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONGHOCPHI> CT_DONGHOCPHI { get; set; }
    }
}
