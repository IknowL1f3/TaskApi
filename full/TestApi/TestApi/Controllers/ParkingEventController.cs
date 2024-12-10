using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TestApi.BLL;
using TestApi.Entities;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class ParkingEventController : ApiController
    {
        private ParkingEventBLL _parkingService = new ParkingEventBLL();

        // GET: api/Parkings
        [HttpGet]
        [ResponseType(typeof(List<ResponseParkingEvent>))]
        public IHttpActionResult GetParkingEvent()
        {
            return Ok(_parkingService.GetAllParkingEvents());
        }

        // GET: api/Parkings/5
        [HttpGet]
        [ResponseType(typeof(ParkingEvent))]
        public IHttpActionResult GetParkingEvent(int id)
        {
            ParkingEvent parkingEvent = _parkingService.GetParkingEvent(id);
            if (parkingEvent == null)
            {
                return NotFound();
            }
            return Ok(parkingEvent);
        }

        // GET: api/Parkings/5
        [HttpGet]
        [ResponseType(typeof(List<ParkingEvent>))]
        [Route("api/ParkingEvent/byUserId/{userId}")]
        public IHttpActionResult GetParkingEventByUserId(int userId)
        {
            List<ParkingEvent> parkingEvent = _parkingService.GetParkingEventByUserId(userId);
            if (parkingEvent == null)
            {
                return NotFound();
            }
            return Ok(parkingEvent);
        }

        // PUT: api/Parkings/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParkingEvent(int id, ParkingEvent parkingEvent)
        {
            if (id != parkingEvent.ParkingEventId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _parkingService.UpdateParkingEvent(parkingEvent);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Parkings
        [HttpPost]
        [ResponseType(typeof(ParkingEvent))]
        public IHttpActionResult PostParkingEvent(ParkingEvent parkingEvent)
        {
            if (parkingEvent == null)
            {
                return BadRequest("Объект = null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _parkingService.AddParkingEvent(parkingEvent);
            return CreatedAtRoute("DefaultApi", new { id = parkingEvent.ParkingId }, parkingEvent);
        }

        // DELETE: api/Parkings/5
        [HttpDelete]
        [ResponseType(typeof(ParkingEvent))]
        public IHttpActionResult DeleteParkingEvent(int id)
        {
            _parkingService.RemoveParkingEvent(id);
            return Ok();
        }
    }
}