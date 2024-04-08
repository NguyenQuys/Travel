using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [Required, StringLength(100)]

        public string TourName { get; set; }

        public string Departure { get; set; }

        public string Destination1 { get; set; }

        public string Destination2 { get; set; }

        public string Destination3 { get; set; }

        public decimal PriceForAdult { get; set; }

        public decimal PriceForChildren { get; set; }

        public int MaxQuantity { get; set; }

        public int Length { get; set; }

        public string NdaysNnights { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string JourneyHightlight { get; set; }

        public string TravelingSchedule { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public bool Hide { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
