using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Repository
{
	public class GenreRespository: BaseRepository<Genre>  ,IGenreRepository
	{
      
		public GenreRespository(IOptions<ConnectionString>connectionString)
            :base(connectionString.Value.IMDBDB)
		{
		}

        public IEnumerable<Genre> GetAll()
        {
            const string query = @"
SELECT[Id]
	,[GenreName] AS [Name]
FROM [Foundation].[Genres](NOLOCK)";

            return GetAll(query);
        }
        public Genre Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[GenreName] AS [Name]
FROM [Foundation].[Genres](NOLOCK)
WHERE Id=@Id";

            return Get(query, new { Id = id });
        }

        public int Add(GenreRequest genre)
        {
            const string query = @"
INSERT INTO [Foundation].[Genres] ([GenreName])
VALUES (@Name)
SELECT [Id] = SCOPE_IDENTITY()";

           return Add(query, new { Name = genre.Name });

        }


        public void Update(int id, GenreRequest genre)
        {
            const string query = @"
UPDATE [Foundation].[Genres]
SET [GenreName] = @Name
WHERE Id = @Id";

            Update(query, new { Name = genre.Name, Id = id });
        }

        public void Delete(int id)
        {

            const string query = @"
DELETE
FROM [Foundation].[Genres]
WHERE Id = @Id";

            Delete(query, new { Id = id });
        }

     

     

    }
}

