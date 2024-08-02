using System;
using Microsoft.Extensions.Options;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Repository
{
	public class MovieRepository:BaseRepository<Movie>,IMovieRepository
	{
        private readonly IProducerRepository _producerRepository;

        public MovieRepository(IOptions<ConnectionString>connectionString, IProducerRepository producerRepository)
            :base(connectionString.Value.IMDBDB)
		{
            _producerRepository = producerRepository;

        }
        public IEnumerable<Movie> GetAll()
        {
            const string query = @"
SELECT [Id]
	,[MovieName] AS [Name]
	,[YearOfRelease]
	,[Plot]
	,[Post] AS [Image]
	,[ProducerId] 
FROM [Foundation].[Movies]";

           return GetAll(query);


        }

        public Movie GetById(int id)
        {
            const string query = @"
SELECT [Id]
	,[MovieName] AS [Name]
	,[YearOfRelease]
	,[Plot]
	,[Post] AS [Image]
	,[ProducerId] 
FROM [Foundation].[Movies]
WHERE Id=@Id";

            return Get(query, new { Id=id});
        }
        public IEnumerable<Movie> GetByYor(int yearOfRelease)
        {
            const string query = @"
SELECT [Id]
	,[MovieName] AS [Name]
	,[YearOfRelease]
	,[Plot]
	,[Post] AS [Image]
	,[ProducerId] 
FROM [Foundation].[Movies]
WHERE YearOfRelease=@YearOfRelease";

         return  GetByYor(query, new { YearOfRelease = yearOfRelease });
        }
        public int Add(MovieRequest movie)
        {
           return AddMovie(new
            {
                MovieName = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Post = movie.Image,
                ProducerID = movie.ProducerId,
                ActorIDs = string.Join(",",movie.Actor),
                GenreIDs = string.Join(",", movie.Genre),
                CreatedAt=(DateTime?)null,
                UpdatedAt = (DateTime?)null,
                Language = (string?)null,
                Profit = (int?)null
            });

       
        }

        public void Update(int id, MovieRequest movie)
        {
            UpdateMovie(new
            {
                MovieId = id,
                MovieName = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Post = movie.Image,
                ProducerID = movie.ProducerId,
                ActorIDs = string.Join(",", movie.Actor),
                GenreIDs = string.Join(",", movie.Genre),
                CreatedAt = (DateTime?)null,
                UpdatedAt = (DateTime?)null,
                Language = (string?)null,
                Profit = (int?)null
            });
        }

        public void Delete(int id)
        {
            const string query = @"

DELETE
FROM [Foundation].[Movies_Actors]
WHERE MovieID = @Id

DELETE
FROM [Foundation].[Movies_Genres]
WHERE MovieId = @Id

DELETE
FROM [Foundation].[Movies]
WHERE Id = @Id

";
            Delete(query, new { Id = id });
        }

        public List<Actor> GetActorListByMovieId(int id)
        {
            const string query = @"
SELECT [Id]
	,[ActorName] AS Name
	,[Bio]
	,[DateOfBirth] AS DOB
	,[Sex] AS [Gender]
FROM [Foundation].[Movies_Actors]
JOIN [Foundation].[Actors] ON [Foundation].[Movies_Actors].[ActorID] = [Foundation].[Actors].[Id]
WHERE [Foundation].[Movies_Actors].MovieID = @Id";

           return  GetActorList(query, new { Id = id }).ToList();
        }

        public List<Genre> GetGenreListByMovieId(int id)
        {
            const string query = @"
SELECT [Id]
	,[GenreName] AS Name
FROM [Foundation].[Movies_Genres]
JOIN [Foundation].[Genres] ON [Foundation].[Movies_Genres].[GenreId] = [Foundation].[Genres].[Id]
WHERE [Foundation].[Movies_Genres].MovieID = @Id";

            return GetGenreList(query, new { Id = id }).ToList();
        }

        public Producer GetProducerById(int producerId)
        {
            return _producerRepository.GetById(producerId);
        }

    }
}
