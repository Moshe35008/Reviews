using System.ComponentModel.DataAnnotations;

namespace Reviews.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1,ErrorMessage ="Please write a name")]
        [MaxLength(20, ErrorMessage = "Please write a description no longer than 20 characters")]
        public string Name { get; set; }
        [Required]
        [Range(1,5,ErrorMessage ="Please enter a rank bewtween 1 and 5")]
        public int Rank { get; set; }
        [Required]
        [MinLength(1,ErrorMessage ="Please enter a description")]
        [MaxLength(100,ErrorMessage = "Please write a description no longer than 100 characters")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
