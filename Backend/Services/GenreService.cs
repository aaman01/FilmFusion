using System;
using System.Numerics;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;
using Rest_api_Assignments.Repository;

namespace Rest_api_Assignments.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRespository;

        public GenreService(IGenreRepository genreRespository)
        {
            _genreRespository = genreRespository;
        }

        public IList<GenreResponse> GetAll()
        {
            var genres = _genreRespository.GetAll();
            List<GenreResponse> genreList = new List<GenreResponse>();
            genres
                .ToList()
                .ForEach(g => genreList.Add(new GenreResponse() { Id = g.Id, Name = g.Name }));
            return genreList;
        }

        public GenreResponse Get(int id)
        {
            var genre = _genreRespository.Get(id);
            return new GenreResponse() { Id = genre.Id, Name = genre.Name };
        }

        public int Create(GenreRequest genre)
        {
            Validations(genre);
            return _genreRespository.Add(genre);
        }

        public void Update(int id, GenreRequest genre)
        {
            if (_genreRespository.Get(id) == null)
            {
                throw new Exception("Please enter valid id of genre");
            }
            Validations(genre);
            _genreRespository.Update(id, genre);
        }

        public void Delete(int id)
        {
            if (_genreRespository.Get(id) == null)
            {
                throw new Exception("Please enter valid id of genre");
            }
            _genreRespository.Delete(id);
        }

        private void Validations(GenreRequest genre)
        {
            if (string.IsNullOrWhiteSpace(genre.Name))
            {
                throw new ArgumentNullException("Please enter valid genre name");
            }
        }
    }
}

