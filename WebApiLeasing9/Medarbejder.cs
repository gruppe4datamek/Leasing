namespace WebApiLeasing9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medarbejder")]
    public partial class Medarbejder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medarbejder()
        {
            Leasings = new HashSet<Leasing>();
        }

        [Key]
        public int Medarbejder_id { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? CPRnummer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leasing> Leasings { get; set; }
    }
}
