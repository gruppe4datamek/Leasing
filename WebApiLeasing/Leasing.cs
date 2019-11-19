namespace WebApiLeasing
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Leasing")]
    public partial class Leasing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Leasing_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dato_Fra { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dato_Til { get; set; }

        [Column("Max kilometer")]
        public int? Max_kilometer { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        [Column("Service Aftale")]
        public int Service_Aftale { get; set; }

        public int Kunde_id { get; set; }

        public int Bil_id { get; set; }

        public int Medarbejder_id { get; set; }

        public virtual Bil Bil { get; set; }

        public virtual Kunde Kunde { get; set; }

        public virtual Medarbejder Medarbejder { get; set; }
    }
}
