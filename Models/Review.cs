using System;
using System.ComponentModel.DataAnnotations;


namespace RESTauranter.Models
{
    public class Review : BaseEntity
    {

        private DateTime CurrentDate;

        public Review () {
            CurrentDate = DateTime.Now;
        }

        [Key]
        public long id { get; set; }

        [Required]
        [Display(Name = "reviewer name")]
        public string reviewer_name { get; set; }
 
        [Required]
        [Display(Name = "restaurant name")]
        public string restaurant_name { get; set; }
 
        [Required]
        [MinLength(10, ErrorMessage = "Review field must have a minimum length of 10 characters")]
        public string review { get; set; }

 
        [Required(ErrorMessage = "Date of Visit must be entered")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [InThePast]
        public DateTime date { get; set; }

        [Required]
        public string stars { get; set; }  

        public DateTime created_at { get; set; } 

        public DateTime updated_at { get; set; }



        
  
    }
}