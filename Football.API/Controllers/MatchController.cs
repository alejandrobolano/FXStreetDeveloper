using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Football.API.Common.Models;
using Football.API.DataAccess;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly FootballContext _footballContext;
        public MatchController(FootballContext footballContext)
        {
            _footballContext = footballContext;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<MatchResponse>> Get()
        {
            return Ok(_footballContext.Matches);
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var response = _footballContext.Matches.Find(id);
            if (response == default)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(MatchResponse match)
        {
            var response = _footballContext.Matches.Add(match).Entity;
            return CreatedAtRoute(response.Id, response);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, MatchResponse match)
        {
            if (_footballContext.Matches.Find(id) == default)
                return NotFound();

            _footballContext.Matches.Update(match);
            return Ok(match);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var match = _footballContext.Matches.Find(id);
            if (match == default)
                return NotFound();

            _footballContext.Matches.Remove(match);
            return Ok("Delete successful");
        }
    }
}
