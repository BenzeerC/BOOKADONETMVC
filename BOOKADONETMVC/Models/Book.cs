using System.ComponentModel.DataAnnotations;
namespace BOOKADONETMVC.Models
{
    public class Book
    {

        [Key]//do define this id pk column in db
        [ScaffoldColumn(false)]//because this is identity column,no need to show on form
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }//? allo null form the data base
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Authour { get; set; }
        [Required]
        public int isActive { get; set; }
    }
}
