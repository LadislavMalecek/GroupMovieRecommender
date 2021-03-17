using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace GroupMovieRecommender.Server.Models
{
    public class Movie
    {
        public static void Configure(EntityTypeBuilder<Movie> builder)
        { }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
