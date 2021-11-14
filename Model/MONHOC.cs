namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MONHOC")]
    public partial class MONHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONHOC()
        {
            LOPTINCHIs = new HashSet<LOPTINCHI>();
        }

        [Key]
        [StringLength(10)]
        public string MAMH { get; set; }

        [Required]
        [StringLength(50)]
        public string TENMH { get; set; }

        public int SOTIET_LT { get; set; }

        public int SOTIET_TH { get; set; }

        public Guid rowguid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPTINCHI> LOPTINCHIs { get; set; }
    }
}
