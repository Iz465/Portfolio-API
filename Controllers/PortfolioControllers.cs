using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

using IsakSiteApi.Models;
using IsakSiteApi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using IsakSiteApi.Enums;
using IsakSiteApi.Dtos;

namespace IsakSiteApi.Controllers
{
    [ApiController]
    [Route("api/portfolio")]
    public class PortfolioControllers : ControllerBase
    {

        private readonly IPortfolio _services;

        public PortfolioControllers(IPortfolio services) =>
            _services = services;


        [HttpGet]
        public async Task<List<Portfolio>> GetPortfolios()
        {
            Console.WriteLine("Accessing portfolio GET method");
            return await _services.GetPortfolios();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePortfolio(int id, PortfolioUpdateDto dto)
        {

            EPortfolio result = await _services.UpdatePortfolio(id, dto);

            if (result == EPortfolio.NotFound)
                return NotFound();

            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> CreatePortfolio(Portfolio portfolio)
        {

            EPortfolio result = await _services.CreatePortfolio(portfolio);

            if (result == EPortfolio.AlreadyExists)
                return Conflict();

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePortfolio(int id)
        {

            EPortfolio result = await _services.DeletePortfolio(id);

            if (result == EPortfolio.NotFound)
                return NotFound();

            return Ok();
        }


    }
}
