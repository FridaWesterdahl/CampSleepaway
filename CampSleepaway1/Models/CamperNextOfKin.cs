using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1.Models
{
    [Table("CamperNextOfKins")]
    public class CamperNextOfKin
    {
        [Column("CamperNextOfKinId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public int CamperId { get; set; }
        public int NextOfKinId { get; set; }

        public virtual Camper Camper { get; set; }
        public virtual NextOfKin NextOfKin { get; set; }
    }
}
