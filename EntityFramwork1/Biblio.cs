namespace EntityFramwork1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Biblio : DbContext
    {
        public Biblio()
            : base("name=Biblio")
        {
        }

        public virtual DbSet<Adherent> Adherents { get; set; }
        public virtual DbSet<Livre> Livres { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }

        //l API fluent
        protected override void 
            OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adherent>()
                .HasKey(e=>e.CodeA)
                .Property(e => e.NomA)
                .IsUnicode(false);

            modelBuilder.Entity<Adherent>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Adherent>()
                .Property(e => e.Couleur)
                .IsUnicode(false);

            modelBuilder.Entity<Livre>()
                .Property(e => e.CodeL)
                .IsUnicode(false);

            modelBuilder.Entity<Livre>()
                .Property(e => e.Titre)
                .IsUnicode(false);

            modelBuilder.Entity<Livre>()
                .Property(e => e.Auteur)
                .IsUnicode(false);

            modelBuilder.Entity<Theme>()
                .Property(e => e.IntituleTh)
                .IsUnicode(false);
        }
    }
}
