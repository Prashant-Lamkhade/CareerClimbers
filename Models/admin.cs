namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        [Key]
        public int aid { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string aname { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string phoneno { get; set; }
    }
}
