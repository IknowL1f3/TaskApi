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
    public class UserController : ApiController
    {
        private UserBLL _userService = new UserBLL();

        // GET: api/Parkings
        [HttpGet]
        [ResponseType(typeof(List<ResponseUser>))]
        public IHttpActionResult GetUser()
        {
            return Ok(_userService.GetAllUsers());
        }

        // GET: api/Parkings/5
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("api/User/byCarNumber/{carNumber}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUserByCarNumber(string carNumber)
        {
            User user = _userService.GetUserByCarNumber(carNumber);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Parkings/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.UpdateUser(user);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Parkings
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (user == null)
            {
                return BadRequest("Объект = null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.AddUser(user);
            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Parkings/5
        [HttpDelete]
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            _userService.RemoveUser(id);
            return Ok();
        }
    }
}