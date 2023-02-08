using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Football.API.Common.Models;
using Football.API.DataAccess;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly FootballContext _footballContext;
        public PlayerController(FootballContext footballContext)
        {
            _footballContext = footballContext;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<PlayerResponse>> Get()
        {
            return Ok(_footballContext.Players);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var response = _footballContext.Players.Find(id);
            if (response == default)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(PlayerResponse player)
        {
            var response = _footballContext.Players.Add(player).Entity;
            return CreatedAtRoute( response.Id, response);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, PlayerResponse player)
        {
            if (_footballContext.Players.Find(id) == default)
                return NotFound();

            _footballContext.Players.Update(player);        
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var player = _footballContext.Players.Find(id);
            if (player == default)
                return NotFound();

            _footballContext.Players.Remove(player);
            return Ok("Delete successful");
        }
    }
}
