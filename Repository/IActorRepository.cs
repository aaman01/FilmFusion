using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Repository
{
	public interface IActorRepository
	{
        IEnumerable<Actor> GetAll();
        int Add(ActorRequest actor);
        Actor GetById(int id);
        void Update(int id, ActorRequest actor);
        void Delete(int id);
    }
}

