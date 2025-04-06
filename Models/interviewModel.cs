using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class interviewModel : DbContext
    {
        public interviewModel()
            : base("name=interviewModel1")
        {
        }

        public virtual DbSet<interview> interviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<interview>()
                .Property(e => e.question)
                .IsUnicode(false);

            modelBuilder.Entity<interview>()
                .Property(e => e.solution)
                .IsUnicode(false);

            modelBuilder.Entity<interview>()
                .Property(e => e.difficulty)
                .IsUnicode(false);

            modelBuilder.Entity<interview>()
                .Property(e => e.category)
                .IsUnicode(false);
        }
    }
}
