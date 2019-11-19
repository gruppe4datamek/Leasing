namespace WebApiLeasing
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Bil_id { get; set; }

        [StringLength(50)]
        public string Mærke { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Årgang { get; set; }

        public int? Kilometertal { get; set; }

        [StringLength(30)]
        public string Farve { get; set; }
    }
}
