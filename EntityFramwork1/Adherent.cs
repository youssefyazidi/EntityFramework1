namespace EntityFramwork1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adherent")]
    public partial class Adherent
    {
        public int CodeA { get; set; }
        [StringLength(80)]
        public string NomA { get; set; }

        [StringLength(100)]
        public string Adresse { get; set; }

        public DateTime? DateInscription { get; set; }

        [StringLength(50)]
        public string Couleur { get; set; }
    }
}
