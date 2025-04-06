namespace CareerClimbers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mentorship")]
    public partial class Mentorship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mentorship_id { get; set; }

        public int mentor_id { get; set; }

        public int mentee_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string progress { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string status { get; set; }
    }
}
