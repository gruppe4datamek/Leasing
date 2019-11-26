namespace WebApiLeasing
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bil")]
    public partial class Bil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bil()
        {
            Leasings = new HashSet<Leasing>();
        }

        [Key]
        public int Nummerplade { get; set; }

        [StringLength(50)]
        public string Mærke { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Årgang { get; set; }

        public int? Kilometertal { get; set; }

        [StringLength(30)]
        public string Farve { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leasing> Leasings { get; set; }
    }
}
