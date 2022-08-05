using System.ComponentModel.DataAnnotations;

namespace BookSellingWebsite_Assessment_04_.Model
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
