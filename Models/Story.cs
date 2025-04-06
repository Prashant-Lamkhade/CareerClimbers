namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Story
    {
        [Key]
        public int story_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string title { get; set; }

        public int str_user_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string company { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string media_links { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string category { get; set; }

        [Column(TypeName = "date")]
        public DateTime published_at { get; set; }
    }
}
