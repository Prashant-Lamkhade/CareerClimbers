namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Profiles = new HashSet<Profile>();
            Stories = new HashSet<Story>();
        }

        [Key]
        public int user_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string password { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string role { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string profile_picture { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profile> Profiles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Story> Stories { get; set; }
    }
}
