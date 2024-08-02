using System;
using Microsoft.Extensions.Options;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Repository
{
    public class ReviewRepository :BaseRepository<Review>, IReviewRepository
    {

        public ReviewRepository(IOptions<ConnectionString>connectionString)
            :base(connectionString.Value.IMDBDB)
        {
            
        }

        public IEnumerable<Review> GetAll()
        {
            const string query = @"
SELECT [Id]
	,[MovieId]
	,[Message]
FROM [Foundation].[Reviews]";

            return GetAll(query);

        }

        public Review Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[MovieId]
	,[Message]
FROM [Foundation].[Reviews]
WHERE Id = @Id";

            return Get(query, new { Id = id });
        }

        public int Add(ReviewRequest review)
        {
            const string query = @"
INSERT INTO [Foundation].[Reviews](
	[MovieId]
	,[Message]
	)
VALUES (
	@MovieId
	,@Message
	)
SELECT [Id] = SCOPE_IDENTITY()";

           return Add(query, new { MovieId = review.MovieId, Message = review.Message });
        }

        public void Update(int id, ReviewRequest review)
        {
            const string query = @"
UPDATE [Foundation].[Reviews]
SET [MovieId] = @MovieId
	,[Message] = @Message
WHERE Id = @Id";

            Update(query, new { MovieId = review.MovieId, Message = review.Message, Id = id });
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM [Foundation].[Reviews]
WHERE Id = @Id";

            Delete(query, new { Id = id });
        }

       
    

    }
}

