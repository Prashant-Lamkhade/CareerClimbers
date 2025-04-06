using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class ratingModel : DbContext
    {
        public ratingModel()
            : base("name=ratingModel")
        {
        }

        public virtual DbSet<ratingT> ratingTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ratingT>()
                .Property(e => e.comments)
                .IsUnicode(false);
        }
    }
}
