using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSellingAssessment_API_.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]

        [MaxLength(10, ErrorMessage = "Last Name should not be more than 40 char")]
        public string Name { get; set; }

        [Required]

        [MaxLength(10, ErrorMessage = "Last Name should not be more than 10 char")]
        public string Zoner { get; set; }

        [Required]


        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public int Cost { get; set; }

    }
}
