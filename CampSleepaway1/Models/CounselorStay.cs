using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1.Models
{
    [Table("CounselorStays")]
    public class CounselorStay
    {
        [Column("CounselorStayId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("ArrivalDate")]
        [Required]
        public DateTime ArrivalDates { get; set; }

        [Column("DepartureDate")]
        public DateTime DepartureDates { get; set; }

        [ForeignKey("CounselorId")]
        public virtual List<Counselor> Counselors { get; set; }
    }
}
