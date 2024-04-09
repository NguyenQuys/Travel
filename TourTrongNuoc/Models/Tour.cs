using System.ComponentModel.DataAnnotations;

namespace TourTrongNuoc.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Range(0.1, 100000.0)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }


    }
}
