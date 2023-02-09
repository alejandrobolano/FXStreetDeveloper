using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Football.API.Common.Models;
using Football.API.DataAccess;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        private readonly FootballContext _footballContext;
        public RefereeController(FootballContext footballContext)
        {
            _footballContext = footballContext;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<RefereeResponse>> Get()
        {
            return Ok(_footballContext.Referees);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var response = _footballContext.Referees.Find(id);
            if (response == default)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(RefereeResponse referee)
        {
            var response = _footballContext.Referees.Add(referee).Entity;
            //TODO I have change CreatedAtAction by CreatedAtRoute
            return CreatedAtRoute(response.Id, response);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, RefereeResponse referee)
        {
            if (_footballContext.Referees.Find(id) == default)
                return NotFound();

            _footballContext.Referees.Update(referee);        
            return Ok(referee);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var referee = _footballContext.Referees.Find(id);
            if (referee == default)
                return NotFound();

            _footballContext.Referees.Remove(referee);
            return Ok("Delete successful");
        }
    }
}
