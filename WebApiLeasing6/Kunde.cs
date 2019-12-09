namespace WebApiLeasing6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kunde")]
    public partial class Kunde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kunde()
        {
            Leasings = new HashSet<Leasing>();
        }

        [Key]
        public int Kunde_id { get; set; }

        [StringLength(50)]
        public string Fornavn { get; set; }

        [StringLength(50)]
        public string Efternavn { get; set; }

        public int? CPRnummer { get; set; }

        [Column("E-mail")]
        [StringLength(50)]
        public string E_mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leasing> Leasings { get; set; }
    }
}
