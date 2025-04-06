namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class interview
    {
        [Key]
        public int iid { get; set; }

        public int iprofid { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string question { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string solution { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string difficulty { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string category { get; set; }
    }
}
