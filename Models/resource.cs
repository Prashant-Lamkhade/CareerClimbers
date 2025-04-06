namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class resource
    {
        [Key]
        public int rid { get; set; }

        public int rprofid { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string type { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string link { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string tags { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }
    }
}
