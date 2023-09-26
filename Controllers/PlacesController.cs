using APITraining.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace APITraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {

        public static List<Place> Places = new List<Place>
            {
                new Place{
                Id = Guid.NewGuid(), // 6B29FC40-CA47-1067-B31D-00DD010662DA
                Name = "Bishnudwar",
                Location = "Shivapuri"
                },
            };
        

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Places);
        }


        [HttpGet("{id}")]
        //[Route]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var place = Places.FirstOrDefault(x => x.Id == id);

            if(place == null)
                return NotFound();

            return Ok(place);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Place place)
        {
            if (place == null)
                return BadRequest();

            Place place2 = new Place
            {
                Id = Guid.NewGuid(),
                Name = place.Name,
                Location = place.Location,
            };

            Places.Add(place2);

            return Ok(place2);
        }

        [HttpPatch("{id:Guid}")]
        public IActionResult Patch([FromRoute]Guid id,[FromBody]JsonPatchDocument<Place> patchValue)
        {
            var place = Places.FirstOrDefault(x=> x.Id == id);

            if(place == null)
                return BadRequest();

            patchValue.ApplyTo(place, ModelState);

            
            return Ok(place);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]Guid id,[FromBody] Place places)
        {
            if (places == null)
                return BadRequest();

            var place = Places.FirstOrDefault(x => x.Id == id);

            if(place == null)
                return NotFound();

            place.Location = places.Location;
            place.Name = places.Name;

            return Ok(place);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            var place = Places.FirstOrDefault(x => x.Id == id);

            if(place == null)
                return NotFound();

            Places.Remove(place);

            return Ok(place);
        }
    }
}
