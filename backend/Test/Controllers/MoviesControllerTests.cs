using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Exceptions;
using Api.Controllers;
using Test.Helpers;

namespace Api.Tests
{
    public class MoviesControllerTests : IClassFixture<MoviesServiceFixture>
    {
        private readonly MoviesServiceFixture _fixture;
        private readonly MoviesController _controller;

        public MoviesControllerTests(MoviesServiceFixture fixture)
        {
            _fixture = fixture;
            _controller = new MoviesController(fixture.Service);
        }

        [Fact]
        public async void GetShouldReturnOkResult()
        {
            var result = await _controller.Get();

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void GetClassificationShouldReturnOkResult()
        {
            var movies = (await _fixture.Service.GetMovies()).ToList();
            var result = _controller.GetClassification(movies);

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, (result as OkObjectResult).StatusCode);
        }

        [Fact]
        public void GetClassificationShouldThrowException()
        {
            var movies = new List<Filme>();

            Assert.Throws<HttpException>(() => _controller.GetClassification(movies));
        }
    }
}
