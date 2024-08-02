using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;

namespace Rest_api_Assignments.Services
{
	public interface IMovieService
	{
        IList<MovieResponse> GetAll(int yearOfRelease);
        MovieResponse Get(int id);
        int Create(MovieRequest movie);
        void Update(int id ,MovieRequest movie);
        void Delete(int id);
    }
}

