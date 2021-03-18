using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupMovieRecommender.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GroupMovieRecommender.Server.Logic
{
    public class MoviesLogic
    {
        private readonly ApplicationDbContext _db;

        public MoviesLogic(ApplicationDbContext db)
            => this._db = db;

        public async Task<IEnumerable<Shared.Movie>> Search(string query, int howManyToReturn)
        {
            System.Console.WriteLine(query);
            return await _db.Movies.AsNoTracking()
                .Where(m => m.Name.Contains(query))
                .OrderBy(m => m.Name)
                .Take(howManyToReturn)
                .Select(m => new Shared.Movie(m.Name))
                .ToListAsync();
        }
    }
}