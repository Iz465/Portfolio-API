using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

using IsakSiteApi.Models;

namespace IsakSiteApi.Controllers
{
    [ApiController]
    [Route("api/portfolio")]
    public class PortfolioControllers : ControllerBase
    {
        

        [HttpPost]

        public async Task<ActionResult> CreatePortfolio(Portfolio portfolio)
        {

        
            Console.WriteLine(portfolio.Title);

            Console.WriteLine("Getting all the portfolios in the db");

            return Ok("hehehe");
        }


    }
}
