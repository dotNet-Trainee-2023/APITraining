﻿using APITraining.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using APITraining.Data;
using APITraining.Models.Dto;
using APITraining.services;

namespace APITraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ApiDBContext _dbcontext;

        private readonly IPlaceServices _placeServices;
        public PlacesController(ApiDBContext dbcontext, IPlaceServices placeServices)
        {
            _dbcontext = dbcontext;
            _placeServices = placeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get from database
            var places = await _placeServices.GetAllAsync();

            //fetch from domain model and map to DTO.
            var placeDto = new List<PlaceDto>();
            foreach (var place in places)
            {
                placeDto.Add(new PlaceDto
                {
                    Id = place.Id,
                    Name = place.Name,
                    Location = place.Location,
                }
                );
            }

            //Return DTO
            return Ok(placeDto);
        }


        [HttpGet("{id}")]
        //[Route]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //fetch from db
            var place = await _placeServices.GetbyIdAsync(id);

            if (place == null)
                return NotFound();

            //Map to DTO
            var placeDto = new List<PlaceDto>
            {
                new PlaceDto()
                {
                    Id= place.Id,
                    Name = place.Name,
                    Location = place.Location,

                }
            };

            //Return DTO
            return Ok(placeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlaceCreateDto placeCreateDto)
        {
            if (placeCreateDto == null)
                return BadRequest();

            Place place2 = new Place
            {
                Id = Guid.NewGuid(),
                Name = placeCreateDto.Name,
                Location = placeCreateDto.Location,
            };

            var returnVal = await _placeServices.CreateAsync(place2);

            return Ok(returnVal);
        }

        [HttpPatch("{id:Guid}")]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] JsonPatchDocument<Place> patchValue)
        {
            var place = _dbcontext.Places.FirstOrDefault(x => x.Id == id);

            if (place == null)
                return BadRequest();

            patchValue.ApplyTo(place, ModelState);
            _dbcontext.SaveChanges();

            return Ok(place);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PlaceCreateDto placeCreateDto)
        {
            if (placeCreateDto == null)
                return BadRequest();

            var place = await _placeServices.GetbyIdAsync(id);

            if (place == null)
                return NotFound();

            var retVal = await _placeServices.UpdateAsync(place, placeCreateDto);

            return Ok(retVal);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var place = await _placeServices.GetbyIdAsync(id);

            if (place == null)
                return NotFound();

            var retVal = await _placeServices.DeleteAsync(place);

            return Ok(retVal);
        }
    }
}
