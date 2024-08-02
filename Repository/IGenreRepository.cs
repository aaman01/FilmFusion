using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Repository
{
	public interface IGenreRepository
	{

		IEnumerable<Genre> GetAll();
		Genre Get(int id);
		int Add(GenreRequest genre);
		void Update(int id, GenreRequest genre);
		void Delete(int id);

	}
}

