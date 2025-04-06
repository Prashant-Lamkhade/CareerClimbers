using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class StoryModel : DbContext
    {
        public StoryModel()
            : base("name=StoryModel1")
        {
        }

        public virtual DbSet<Story> Story { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.media_links)
                .IsUnicode(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.category)
                .IsUnicode(false);
        }
    }
}
