using System;
using System.Numerics;
using Microsoft.Extensions.Options;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;

namespace Rest_api_Assignments.Repository
{
    public class ProducerRepository :BaseRepository<Producer> ,IProducerRepository
    {
        
        public ProducerRepository(IOptions<ConnectionString>connectionString)
            :base(connectionString.Value.IMDBDB)
        {
           
        }

        public IEnumerable<Producer> GetAll()
        {
            const string query = @"
SELECT [Id]
	,[ProducerName] AS [Name]
	,[Bio]
	,[DateOfBirth] AS [Dob]
	,[Sex] AS [Gender]
FROM [Foundation].[Producers](NOLOCK)";
            return GetAll(query);
        }

        public Producer GetById(int id)
        {
            const string query = @"
SELECT [Id]
	,[ProducerName] AS [Name]
	,[Bio]
	,[DateOfBirth] AS [Dob]
	,[Sex] AS [Gender]
FROM [Foundation].[Producers](NOLOCK)
WHERE [Id] = @Id";


            return Get(query, new { Id = id });
        }

        public int Add(ProducerRequest producer)
        {
            const string query = @"
INSERT INTO [Foundation].[Producers] (
	[ProducerName]
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
SELECT [Id] = SCOPE_IDENTITY()";
           return Add(query, new { Name = producer.Name, Bio = producer.Bio, Dob = producer.Dob, Sex = producer.Gender });

        }

        public void Update(int id, ProducerRequest producer)
        {
            const string query = @"
UPDATE [Foundation].[Producers]
SET [ProducerName] = @Name
	,[Sex] = @Gender
    ,[Bio]=@Bio
	,[DateOfBirth] = @Dob
WHERE Id = @Id
"
             ;
            Update(query, new { Name = producer.Name, Gender = producer.Gender, Bio = producer.Bio, Dob = producer.Dob, Id = id });
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM [Fondation].[Producers]
WHERE Id = @Id";

            Delete(query, new { Id = id });
        }
    }
}

