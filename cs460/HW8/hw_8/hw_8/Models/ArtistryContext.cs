using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace hw_8.Models
{
    public class ArtistryContext: DbContext
    {
       public ArtistryContext()
            :base("name=ArtistryContext")
        {
        }
        
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtWork> Artworks { get; set; }
        public virtual DbSet<Genre>Genres { get; set; }
        public virtual DbSet<Classifications> Classifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(e => e.ArtWork)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArtWork>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.ArtWork)
                .WillCascadeOnDelete(false);
              

        }
    }
        
}