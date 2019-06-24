using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitDrnk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitDrnk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<Game>> GetGames()
        {
            var gameList = new List<Game>();
            gameList.Add(new Game
            {
                Id = "nice",
                Players = new List<Player>
                {
                    new Player()
                }
            });

            return gameList;
        }
    }
}