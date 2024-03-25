using TourTrongNuoc.Models;

namespace TourTrongNuoc.Repositories
{
    public interface ITourRepository
    {
        IEnumerable<Tour> GetAll();
        Tour GetById(int id);
        void Add(Tour tour);

    }
}
