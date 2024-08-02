using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Repository
{
	public interface IMovieRepository
	{
		IEnumerable<Movie> GetAll();
		Movie GetById(int id);
        IEnumerable<Movie> GetByYor(int yearOfRelease);
		int Add(MovieRequest movie);
		void Update(int id, MovieRequest movie);
		void Delete(int id);
        List<Actor> GetActorListByMovieId(int id);
        List<Genre> GetGenreListByMovieId(int id);
		Producer GetProducerById(int producerId);
    }
}

