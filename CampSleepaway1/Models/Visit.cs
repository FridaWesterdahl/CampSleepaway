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
        [Column("VisitId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("ArrivalDate")]
        [Required]
        public DateTime ArrivalDates { get; set; }

        [Column("DepartureDate")]
        public DateTime DepartureDates { get; set; }

        public int MaxVisitTime { get; set; }
        public DateTime EarliestVisit { get; set; }
        public DateTime LatestVisit { get; set; }

        public int NextOfKinId { get; set; }
        public virtual NextOfKin NextOfKin { get; set; }
        public int CamperId { get; set; }
        public virtual Camper Camper { get; set; }
    }    
}
