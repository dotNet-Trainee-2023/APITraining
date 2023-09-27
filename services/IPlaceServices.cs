using APITraining.Models;
using APITraining.Models.Dto;

namespace APITraining.services
{
    public interface IPlaceServices
    {
        Task<List<Place>> GetAllAsync();

        Task<Place> GetbyIdAsync(Guid id);

        Task<Place> CreateAsync(Place place);

        Task<Place> UpdateAsync(Place place, PlaceCreateDto placeCreateDto);

        Task<Place> DeleteAsync(Place place);
    }
}
