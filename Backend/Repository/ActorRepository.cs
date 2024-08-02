using System;
using System.Numerics;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Repository
{
	public class ActorRepository:BaseRepository<Actor> , IActorRepository
	{
		
		public ActorRepository(IOptions<ConnectionString>connectionString)
			:base(connectionString.Value.IMDBDB)
		{
		}

        public IEnumerable<Actor> GetAll()
        {
			const string query = @"
SELECT [Id]
	,[ActorName] AS [Name]
	,[Bio]
	,[DateOfBirth] AS [Dob]
	,[Sex] AS [Gender]
FROM [Foundation].[Actors](NOLOCK)";
			return GetAll(query);
           
        }

        public Actor GetById(int id)
        {
			const string query = @"
SELECT [Id]
	,[ActorName] AS [Name]
	,[Bio]
	,[DateOfBirth] AS [Dob]
	,[Sex] AS [Gender]
FROM [Foundation].[Actors](NOLOCK)
WHERE [Id] = @Id";


			return Get(query, new  { Id = id });
        }


        public int Add(ActorRequest actor)
		{

			const string query = @"
INSERT INTO [Foundation].[Actors] (
	[ActorName]
	,[Bio]
	,[DateOfBirth]
	,[Sex]
	)
VALUES(
	@Name
	,@Bio
	,@Dob
	,@Sex
	)
 SELECT [Id] = SCOPE_IDENTITY()"
;
			return Add(query, new { Name = actor.Name, Bio = actor.Bio, Dob = actor.Dob, Sex = actor.Gender });

        }

        public void Update(int id, ActorRequest actor)
        {

			const string query = @"
UPDATE [Foundation].[Actors]
SET [ActorName] = @Name
	,[Sex] = @Gender
    ,[Bio]=@Bio
	,[DateOfBirth] = @Dob
WHERE Id = @Id
"
            ;
			Update(query, new { Name = actor.Name, Gender = actor.Gender,Bio=actor.Bio, Dob = actor.Dob, Id = id });
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM [Fondation].[Actors]
WHERE Id = @Id";

            Delete(query, new { Id = id });
        }

    }
}

