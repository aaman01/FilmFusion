using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;

namespace Rest_api_Assignments.Services
{
	public interface IGenreService
	{
        IList<GenreResponse> GetAll();
        GenreResponse Get(int id);
        int Create(GenreRequest genre);
        void Update(int id,GenreRequest genre);
        void Delete(int id);
    }
}

