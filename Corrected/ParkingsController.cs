using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestApi.BLL;
using TestApi.Entities;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class ParkingsController : ApiController
    {
        private ParkingBLL _parkingService = new ParkingBLL();

        // GET: api/Parkings
        [HttpGet]
        [ResponseType(typeof(List<ResponseParking>))]
        public IHttpActionResult GetParking()
        {
            return Ok(_parkingService.GetAllParkings());
        }

        // GET: api/Parkings/5
        [HttpGet]
        [ResponseType(typeof(Parking))]
        public IHttpActionResult GetParking(int id)
        {
            Parking parking = _parkingService.GetParking(id);
            if (parking == null)
            {
                return NotFound();
            }
            return Ok(parking);
        }

        // PUT: api/Parkings/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParking(int id, Parking parking)
        {
            if (id != parking.ParkingId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _parkingService.UpdateParking(parking);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Parkings
        [HttpPost]
        [ResponseType(typeof(Parking))]
        public IHttpActionResult PostParking(Parking parking)
        {
            if (parking == null)
            {
                return BadRequest("Объект = null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _parkingService.AddParking(parking);
            return CreatedAtRoute("DefaultApi", new { id = parking.ParkingId }, parking);
        }

        // DELETE: api/Parkings/5
        [HttpDelete]
        [ResponseType(typeof(Parking))]
        public IHttpActionResult DeleteParking(int id)
        {
            _parkingService.RemoveParking(id);
            return Ok();
        }
    }
}