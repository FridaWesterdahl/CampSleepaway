using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1.Models
{
    [Table ("NextOfKins")]
    public class NextOfKin
    {
        [Column("NextOfKinId")]
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

        [Column("PhoneNumber")]
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [ForeignKey("CamperId")]
        public virtual List<Camper> Campers { get; set; }
    }
}
