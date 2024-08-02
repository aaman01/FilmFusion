using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;


namespace Rest_api_Assignments.Repository
{
	public interface IReviewRepository
	{
        IEnumerable<Review> GetAll();
        Review Get(int id);
        int Add(ReviewRequest review);
        void Update(int id, ReviewRequest review);
        void Delete(int id);


    }
}

