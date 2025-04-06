using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class resourceModel : DbContext
    {
        public resourceModel()
            : base("name=resourceModel4")
        {
        }

        public virtual DbSet<resource> resources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<resource>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.tags)
                .IsUnicode(false);
        }
    }
}
