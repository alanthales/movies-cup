using System.Collections.Generic;
using System.Linq;
using Xunit;
using Domain.Entities;
using Test.Helpers;

namespace Test.Services
{
    public class MoviesServiceTests : IClassFixture<MoviesServiceFixture>
    {
        private readonly MoviesServiceFixture _fixture;

        public MoviesServiceTests(MoviesServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void GetMoviesShouldReturnMovies()
        {
            var movies = await _fixture.Service.GetMovies();

            Assert.NotEmpty(movies);
            Assert.IsType<List<Filme>>(movies);
        }

        [Fact]
        public async void GetFinalistsShouldReturnFinalistsList()
        {
            var movies = (await _fixture.Service.GetMovies()).ToList();
            var finalists = _fixture.Service.GetFinalists(movies).ToList();

            Assert.Contains(finalists, x => x.Id == "tt4154756");
            Assert.Contains(finalists, x => x.Id == "tt3501632");
            Assert.Contains(finalists, x => x.Id == "tt3606756");
            Assert.Contains(finalists, x => x.Id == "tt4881806");
        }

        [Fact]
        public async void GetChampionsShouldReturnClassification()
        {
            var movies = (await _fixture.Service.GetMovies()).ToList();
            var classif = _fixture.Service.GetChampions(movies);

            Assert.True(classif.Vice.Id == "tt3606756");
            Assert.True(classif.Campeao.Id == "tt4154756");
        }
    }
}
