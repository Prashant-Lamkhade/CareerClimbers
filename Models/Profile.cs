namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profile
    {
        [Key]
        public int profile_id { get; set; }

        public int user_fid { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string bio { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string skills { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string educational_background { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string career_goals { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string achievements { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string social_links { get; set; }
    }
}
