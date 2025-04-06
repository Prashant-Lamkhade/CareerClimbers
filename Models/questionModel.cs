using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class questionModel : DbContext
    {
        public questionModel()
            : base("name=questionModel")
        {
        }

        public virtual DbSet<question> questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<question>()
                .Property(e => e.question1)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.difficulty)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.solution)
                .IsUnicode(false);
        }
    }
}
