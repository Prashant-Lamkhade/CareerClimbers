namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ratingT")]
    public partial class ratingT
    {
        [Key]
        public int rating_id { get; set; }

        public int ruserid { get; set; }

        public int rating { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string comments { get; set; }
    }
}
