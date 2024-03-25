using TourTrongNuoc.Models;

namespace TourTrongNuoc.Repositories
{
    public class MockTourRepository : ITourRepository
    {
        private readonly List<Tour> _tours;
        public MockTourRepository()
        {
            // Tạo một số dữ liệu mẫu
            _tours = new List<Tour>
            {
            new Tour { Id = 1, Name = "Tour", Price = 1, Description= "Chuyến đi"},
 // Thêm các sản phẩm khác
            };
        }
        public void Add(Tour tour)
        {
            tour.Id = _tours.Max(p => p.Id) + 1;
            _tours.Add(tour);
        }

        public IEnumerable<Tour> GetAll()
        {
            return _tours;
        }
        public Tour GetById(int id)
        {
            return _tours.FirstOrDefault(p => p.Id == id);
        }
    }
}
