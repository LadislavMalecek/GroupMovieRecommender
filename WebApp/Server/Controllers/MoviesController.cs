using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using GroupMovieRecommender.Server.Logic;

namespace GroupMovieRecommender.Server.Controllers
{
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly MoviesLogic _movieService;

        public MoviesController(MoviesLogic movieService)
            => this._movieService = movieService;

        [HttpGet("_api/movies/search")]
        public async Task<ActionResult> Search(string query, int howManyToReturn)
        {
            try
            {
                return Ok(await _movieService.Search(query, howManyToReturn));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }
    }
}