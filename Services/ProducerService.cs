using System;
using Rest_api_Assignments.Models;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;
using Rest_api_Assignments.Repository;

namespace Rest_api_Assignments.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public IList<ProducerResponse> GetAll()
        {
            var producers = _producerRepository.GetAll();
            List<ProducerResponse> producersList = new List<ProducerResponse>();
            producers
                .ToList()
                .ForEach(
                    p =>
                        producersList.Add(
                            new ProducerResponse
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Bio = p.Bio,
                                Gender = p.Gender,
                                Dob = p.Dob
                            }
                        )
                );

            return producersList;
        }

        public ProducerResponse GetById(int id)
        {
            var producer = _producerRepository.GetById(id);
            if (producer == null)
                throw new ArgumentException("No match found");
            return new ProducerResponse()
            {
                Id = producer.Id,
                Name = producer.Name,
                Bio = producer.Bio,
                Gender = producer.Gender,
                Dob = producer.Dob
            };
        }

        public int Create(ProducerRequest producer)
        {
            Validations(producer);
            return _producerRepository.Add(producer);
        }

        public void Update(int id, ProducerRequest producer)
        {
            if (_producerRepository.GetById(id) == null)
            {
                throw new Exception("Please enter valid id of producer");
            }
            Validations(producer);
            _producerRepository.Update(id, producer);
        }

        public void Delete(int id)
        {
            if (_producerRepository.GetById(id) == null)
            {
                throw new Exception("Please enter valid id of producer");
            }
            _producerRepository.Delete(id);
        }

        private void Validations(ProducerRequest producer)
        {
            if (string.IsNullOrWhiteSpace(producer.Name))
            {
                throw new ArgumentNullException("Please enter valid producer name");
            }
            if (string.IsNullOrWhiteSpace(producer.Bio))
            {
                throw new ArgumentNullException("Please enter valid bio");
            }
            if (string.IsNullOrWhiteSpace(producer.Gender))
            {
                throw new ArgumentNullException("Please enter valid gender ");
            }
            if (producer.Dob <= DateTime.MinValue || producer.Dob > DateTime.Today)
            {
                throw new InvalidDataException("Please enter valid Dob ");
            }
        }
    }
}

