using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1.Models
{
    [Table ("Counselors")]
    public class Counselor
    {
        [Column("CounselorId")]
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

        [Column("Title")]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
