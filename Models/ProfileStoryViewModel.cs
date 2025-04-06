using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CareerClimbers.Models
{
    public partial class ProfileStoryViewModel : DbContext
    {
        public ProfileStoryViewModel()
            : base("name=ProfileStoryViewModel")
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(e => e.bio)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.skills)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.educational_background)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.career_goals)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.achievements)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.social_links)
                .IsUnicode(false);

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
