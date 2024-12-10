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
    public class BalanceController : ApiController
    {
        private BalanceBLL _balanceService = new BalanceBLL();

        // GET: api/Parkings
        [HttpGet]
        [ResponseType(typeof(List<ResponseBalance>))]
        public IHttpActionResult GetBalance()
        {
            return Ok(_balanceService.GetAllBalances());
        }

        // GET: api/Parkings/5
        [HttpGet]
        [ResponseType(typeof(Balance))]
        public IHttpActionResult GetBalance(int id)
        {
            Balance balance = _balanceService.GetBalance(id);
            if (balance == null)
            {
                return NotFound();
            }
            return Ok(balance);
        }

        // PUT: api/Parkings/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBalance(int id, Balance balance)
        {
            if (id != balance.BalanceId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _balanceService.UpdateBalance(balance);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Parkings
        [HttpPost]
        [ResponseType(typeof(Balance))]
        public IHttpActionResult PostBalance(Balance balance)
        {
            if (balance == null)
            {
                return BadRequest("Объект = null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _balanceService.AddBalance(balance);
            return CreatedAtRoute("DefaultApi", new { id = balance.BalanceId }, balance);
        }

        // DELETE: api/Parkings/5
        [HttpDelete]
        [ResponseType(typeof(Balance))]
        public IHttpActionResult DeleteBalance(int id)
        {
            _balanceService.RemoveBalance(id);
            return Ok();
        }
    }
}