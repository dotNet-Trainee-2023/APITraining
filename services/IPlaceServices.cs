using APITraining.Models;
using APITraining.Models.Dto;

namespace APITraining.services
{
    public interface IPlaceServices
    {
        Task<List<Place>> GetAllAsync(int pageNumber = 1, int pageSize = 10);

        Task<Place> GetbyIdAsync(Guid id);

        Task<Place> CreateAsync(Place place);

        Task<Place> UpdateAsync(Place place, PlaceCreateDto placeCreateDto);

        Task<Place> DeleteAsync(Place place);
    }
}
