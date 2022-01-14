using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1.Models
{ 
    [Table("Cabins")]
    public class Cabin
    {
        [Column("CabinId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("CabinName")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int CapacityCampers { get; set; }
        public int CapacityCounselor { get; set; }

        public virtual List<CamperStay> CamperStays { get; set; }
        public virtual List<CounselorStay> CounselorStays { get; set; }

    }
}
