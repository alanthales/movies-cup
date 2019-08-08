using Repository;
using Service;

namespace Test.Helpers
{
    public class MoviesServiceFixture
    {
        public IMoviesService Service { get; private set; }

        public MoviesServiceFixture()
        {
            this.Service = new MoviesService(new MoviesRepository(new MockApi()));
        }
    }
}