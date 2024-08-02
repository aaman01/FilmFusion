using System;
using System.Text.RegularExpressions;
using Rest_api_Assignments.Models;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;
using Rest_api_Assignments.Repository;

namespace Rest_api_Assignments.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public IList<ActorResponse> GetAll()
        {
            var actor = _actorRepository.GetAll();

            List<ActorResponse> actorList = new List<ActorResponse>();
            actor
                .ToList()
                .ForEach(
                    a =>
                        actorList.Add(
                            new ActorResponse
                            {
                                Id = a.Id,
                                Name = a.Name,
                                Bio = a.Bio,
                                Gender = a.Gender,
                                Dob = a.Dob
                            }
                        )
                );
            return actorList;
        }

        public ActorResponse GetById(int id)
        {
            var actor = _actorRepository.GetById(id);

            return new ActorResponse()
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                Dob = actor.Dob,
                Gender = actor.Gender
            };
        }

        public int Create(ActorRequest actor)
        {
            Validations(actor);
            return _actorRepository.Add(actor);
        }

        public void Update(int id, ActorRequest actor)
        {
            if (_actorRepository.GetById(id) == null)
            {
                throw new Exception("Please enter valid id of actor");
            }
            Validations(actor);
            _actorRepository.Update(id, actor);
        }

        public void Delete(int id)
        {
            if (_actorRepository.GetById(id) == null)
            {
                throw new Exception("Please enter valid id of actor");
            }
            _actorRepository.Delete(id);
        }

        private void Validations(ActorRequest actor)
        {
            if (string.IsNullOrWhiteSpace(actor.Name))
            {
                throw new ArgumentNullException("Please enter valid actor name");
            }
            if (string.IsNullOrWhiteSpace(actor.Bio))
            {
                throw new ArgumentNullException("Please enter valid bio");
            }
            if (string.IsNullOrWhiteSpace(actor.Gender))
            {
                throw new ArgumentNullException("Please enter valid gender ");
            }
            if (actor.Dob <= DateTime.MinValue || actor.Dob > DateTime.Today)
            {
                throw new InvalidDataException("Please enter valid Dob ");
            }
        }
    }
}

