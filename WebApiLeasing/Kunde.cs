namespace WebApiLeasing
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
            Leasing = new HashSet<Leasing>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kunde_id { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }

        [Column("Tlf.nr")]
        public int? Tlf_nr { get; set; }

        [StringLength(50)]
        public string Adresse { get; set; }

        [Column("E-mail")]
        [StringLength(50)]
        public string E_mail { get; set; }

        [Column("CPR.nr")]
        public int? CPR_nr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leasing> Leasing { get; set; }
    }
}
