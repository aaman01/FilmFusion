using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;

namespace Rest_api_Assignments.Repository
{
	public interface IProducerRepository
	{
		IEnumerable<Producer> GetAll();
		Producer GetById(int id);
		int Add(ProducerRequest producer);
		void Update(int id, ProducerRequest producer);
		void Delete(int id);
	}
}

