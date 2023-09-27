using APITraining.Data;
using APITraining.Models;
using APITraining.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace APITraining.services
{
    public class PlaceServices : IPlaceServices
    {
        private readonly ApiDBContext _dbContext;
        public PlaceServices(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Place>  CreateAsync(Place place)
        {
            //Add to db
            await _dbContext.Places.AddAsync(place);
            await _dbContext.SaveChangesAsync();

            return place;
        }

        public async Task<Place> DeleteAsync(Place place)
        { 
            _dbContext.Places.Remove(place);
            await _dbContext.SaveChangesAsync();

            return place;
        }

        public async Task<List<Place>> GetAllAsync()
        {
             return await _dbContext.Places.ToListAsync();
        }

        public async Task<Place> GetbyIdAsync(Guid id)
        {
            return _dbContext.Places.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Place> UpdateAsync(Place place, PlaceCreateDto placeCreateDto)
        {
            place.Location = string.IsNullOrEmpty(placeCreateDto.Location) ? place.Location : placeCreateDto.Location;
            place.Name = string.IsNullOrEmpty(placeCreateDto.Name) ? place.Name : placeCreateDto.Name;

            await _dbContext.SaveChangesAsync();

            return place;
        }
    }
}
