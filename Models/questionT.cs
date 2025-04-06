namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("questionT")]
    public partial class questionT
    {
        [Key]
        public int qid { get; set; }

        public int qprofid { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string question { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string category { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string difficulty { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string solution { get; set; }
    }
}
