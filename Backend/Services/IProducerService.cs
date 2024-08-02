using System;
using Rest_api_Assignments.Models.Response;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Services
{
	public interface IProducerService
	{
        IList<ProducerResponse> GetAll();
        ProducerResponse GetById(int id);
        int Create(ProducerRequest producer);
        void Update(int id ,ProducerRequest producer);
        void Delete(int id);
    }
}

