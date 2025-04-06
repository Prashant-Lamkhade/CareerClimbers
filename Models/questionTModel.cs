using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class questionTModel : DbContext
    {
        public questionTModel()
            : base("name=questionTModel")
        {
        }

        public virtual DbSet<questionT> questionTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<questionT>()
                .Property(e => e.question)
                .IsUnicode(false);

            modelBuilder.Entity<questionT>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<questionT>()
                .Property(e => e.difficulty)
                .IsUnicode(false);

            modelBuilder.Entity<questionT>()
                .Property(e => e.solution)
                .IsUnicode(false);
        }
    }
}
