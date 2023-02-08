using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Football.API.DataAccess;

namespace Football.API.Controllers
{
    //TODO Can be better add Action in route like this /api/[controller]/[action]
    [Route("/api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly FootballContext _footballContext;
        public StatisticsController(FootballContext footballContext)
        {
            _footballContext = footballContext;
        }

        [HttpGet]
        [Route("yellowcards")]
        public async Task<ActionResult> GetYellowCards()
        {
            return Ok("ok");
        }

        [HttpGet]
        [Route("redcards")]
        public ActionResult GetRedCards()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("minutesplayed")]
        public ActionResult GetMinutesPlayed()
        {
            throw new NotImplementedException();
        }
    }
}
