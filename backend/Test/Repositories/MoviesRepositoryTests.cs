using System.Linq;
using Xunit;
using Domain.Exceptions;
using Repository;
using Test.Helpers;

namespace Test.Repositories
{
    public class MoviesRepositoryTests
    {
        [Fact]
        public async void GetShouldReturnMovies()
        {
            var repository = new MoviesRepository(new MockApi());
            var movies = await repository.Get();

            Assert.True(movies.Count() == 8);
            Assert.Equal("tt3606756", movies.First().Id);
        }

        [Fact]
        public void GetShouldThrowException()
        {
            var repository = new MoviesRepository(new MockApiError());

            Assert.ThrowsAsync<HttpException>(() => repository.Get());
        }
    }
}
