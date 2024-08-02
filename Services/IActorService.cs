using Rest_api_Assignments.Models;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;

namespace Rest_api_Assignments.Services
{
    public interface IActorService
    {
        IList<ActorResponse> GetAll();
        ActorResponse GetById(int id);
        int Create(ActorRequest actor);
        void Update(int id,ActorRequest actor);
        void Delete(int id);
    }
}