using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;
using Rest_api_Assignments.Repository;

namespace Rest_api_Assignments.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IList<MovieResponse> GetAll(int yearOfRelease)
        {
            IEnumerable<Movie> movie;
            List<MovieResponse> movieList = new List<MovieResponse>();

            if (yearOfRelease != 0)
            {
                movie = _movieRepository.GetByYor(yearOfRelease);
            }
            else
            {
                movie = _movieRepository.GetAll();
            }
            movie
                .ToList()
                .ForEach(
                    m =>
                        movieList.Add(
                            new MovieResponse()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                YearOfRelease = m.YearOfRelease,
                                Plot = m.Plot,
                                Actor = _movieRepository.GetActorListByMovieId(m.Id),
                                Genre = _movieRepository.GetGenreListByMovieId(m.Id),
                                Producer = _movieRepository.GetProducerById(m.ProducerId),
                                Image = m.Image
                            }
                        )
                );
            return movieList;
        }

        public MovieResponse Get(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new ArgumentException("No match found");
            }
            return new MovieResponse()
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Actor = _movieRepository.GetActorListByMovieId(movie.Id),
                Genre = _movieRepository.GetGenreListByMovieId(movie.Id),
                Producer = _movieRepository.GetProducerById(movie.ProducerId),
                Image = movie.Image
            };
        }

        public int Create(MovieRequest movie)
        {
            Validations(movie);
            return _movieRepository.Add(movie);
        }

        public void Update(int id, MovieRequest movie)
        {
            if (_movieRepository.GetById(id) == null)
            {
                throw new Exception("Please enter valid id of movie");
            }

            Validations(movie);
            _movieRepository.Update(id, movie);
        }

        public void Delete(int id)
        {
            if (_movieRepository.GetById(id) == null)
            {
                throw new Exception("Please enter valid id of movie");
            }
            _movieRepository.Delete(id);
        }

        private void Validations(MovieRequest movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Name))
            {
                throw new ArgumentNullException("Please enter valid movie name");
            }
            if (string.IsNullOrWhiteSpace(movie.Plot))
            {
                throw new ArgumentNullException("Please enter valid plot");
            }
            if (string.IsNullOrWhiteSpace(movie.Image))
            {
                throw new ArgumentNullException("Please enter valid image ");
            }
            if (movie.ProducerId == null || movie.ProducerId <= 0)
            {
                throw new ArgumentNullException("Please enter valid producerId ");
            }
            if (movie.Actor == null)
            {
                throw new ArgumentNullException("Please enter valid list of ActorIds ");
            }
            if (movie.Genre == null)
            {
                throw new ArgumentNullException("Please enter valid GenreIds");
            }
        }
    }
}

