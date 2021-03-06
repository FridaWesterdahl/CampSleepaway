using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1.Models
{
    [Table("Campers")]
    public class Camper
    {
        [Column("CamperId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("FirstName")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column("Age")]
        [Required]
        public int Age { get; set; }

        public virtual List<Visit> Visit { get; set; }

    }
}
