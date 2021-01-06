namespace MVC_Template_Ornek_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kisiler")]
    public partial class Kisiler
    {
        [Key]
        public int KisiId { get; set; }

        [Required]
        [StringLength(50)]
        public string KisiSoyadi { get; set; }

        [StringLength(20)]
        public string Sehir { get; set; }
    }
}
