using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dataAccessLayer
{
    public class StudentInformation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter valid Email")]
        [RegularExpression(@"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Mobile Number")]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^[6-9][0-9]{9}$",ErrorMessage ="MobileNumber Formate Incorrect")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage ="Enter the State")]
        [Display(Name = "State")]
        public int StateId { get; set; }
        public string StateName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Select date of birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
