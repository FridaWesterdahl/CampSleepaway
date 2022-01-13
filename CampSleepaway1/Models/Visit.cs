using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1.Models
{
    [Table("Visit")]
    public class Visit
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("ArrivalDate")]
        [Required]
        public DateTime ArrivalDates { get; set; }

        [Column("DepartureDate")]
        [Required]
        public DateTime DepartureDates { get; set; }

        public int MaxVisitTime { get; set; }
        public DateTimeOffset EarliestVisit { get; set; }
        public DateTimeOffset LatestVisit { get; set; }

        [ForeignKey("Id")]
        public virtual List<NextOfKin> NextOfKins { get; set; }
    }    
}
