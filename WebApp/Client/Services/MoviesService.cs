using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GroupMovieRecommender.Shared;
using Microsoft.AspNetCore.Components;

namespace GroupMovieRecommender.Client.Services
{
    public class MoviesService
    {
        private readonly HttpClient _httpClient;
        public MoviesService(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<IEnumerable<Movie>> SearchMovies(string query, int howManyToReturn)
        {
            return await _httpClient.GetFromJsonAsync<Movie[]>($"_api/movies/search?query={query}&howmanytoreturn={howManyToReturn}");
        }
    }
}