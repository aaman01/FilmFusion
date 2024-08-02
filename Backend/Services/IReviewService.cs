using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;

namespace Rest_api_Assignments.Services
{
	public interface IReviewService
	{
        IList<ReviewResponse> GetAll();
        ReviewResponse Get(int id);
        int Create(ReviewRequest review);
        void Update(int id,ReviewRequest review);
        void Delete(int id);
    }
}

