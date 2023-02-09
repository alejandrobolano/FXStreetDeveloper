using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.API.Business.Contracts;
using Football.API.Common.Models;
using Football.API.DataAccess;

namespace Football.API.Controllers
{
    //TODO Can be better add Action in route like this /api/[controller]/[action]
    [Route("/api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly FootballContext _footballContext;
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(FootballContext footballContext, IStatisticsService statisticsService )
        {
            _footballContext = footballContext;
            _statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("yellowcards")]
        public async Task<ActionResult> GetYellowCards()
        {
            //ToDo Get data from Match, Player and send it by param
            var response = _statisticsService.GetYellowCards();
            return Ok(response);
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
