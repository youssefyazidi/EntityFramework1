namespace EntityFramwork1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Livre")]
    public partial class Livre
    {
        [Key]
        [StringLength(10)]
        public string CodeL { get; set; }

        [StringLength(80)]
        public string Titre { get; set; }

        [StringLength(80)]
        public string Auteur { get; set; }

        public int? NbExemplaires { get; set; }

        public int? CodeTh { get; set; }

        public virtual Theme Theme { get; set; }
    }
}
