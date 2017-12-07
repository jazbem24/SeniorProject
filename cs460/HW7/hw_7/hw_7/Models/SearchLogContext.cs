namespace hw_7.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SearchLogContext : DbContext
    {
        public SearchLogContext()
            : base("name=SearchLogContext")
        {
        }

        public virtual DbSet<SearchLog> SearchLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchLog>()
                .Property(e => e.SearchRequest)
                .IsUnicode(false);

            modelBuilder.Entity<SearchLog>()
                .Property(e => e.Agent)
                .IsUnicode(false);

            modelBuilder.Entity<SearchLog>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);
        }
    }
}
