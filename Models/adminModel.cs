using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class adminModel : DbContext
    {
        public adminModel()
            : base("name=adminModel")
        {
        }

        public virtual DbSet<admin> admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.aname)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.phoneno)
                .IsUnicode(false);
        }
    }
}
