using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Entities
{
    public class JobSeeker
    {

        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }
        //public User JobSeekerUser { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Experience { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public Nullable<DateTime> DateOfBirth { get; set; }

       

    }
}
