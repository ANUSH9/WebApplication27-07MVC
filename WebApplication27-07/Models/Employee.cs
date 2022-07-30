using System.ComponentModel.DataAnnotations;

namespace WebApplication27_07.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [MaxLength(15, ErrorMessage = "Name cannot be longer than 10 characters.")]
        public String Firstname { get; set; }

        [MaxLength(15, ErrorMessage = "Name cannot be longer than 10 characters.")]
        public String LastName { get; set; }

        [MaxLength(10, ErrorMessage = "Name cannot be longer than 10 characters.")]

        public String MobileNo { get; set; }
        
        public String Email { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        [MaxLength(15, ErrorMessage = "Name cannot be longer than 10 characters.")]

        public String City { get; set; }
        public String PostalCode { get; set; }
       
        public String Country { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }



    }
}
