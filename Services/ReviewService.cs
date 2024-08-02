using System;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Models.Response;
using Rest_api_Assignments.Repository;

namespace Rest_api_Assignments.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IList<ReviewResponse> GetAll()
        {
            var reviews = _reviewRepository.GetAll();
            List<ReviewResponse> _reviewList = new List<ReviewResponse>();
            reviews
                .ToList()
                .ForEach(
                    r =>
                        _reviewList.Add(
                            new ReviewResponse()
                            {
                                Id = r.Id,
                                Message = r.Message,
                                MovieId = r.MovieId
                            }
                        )
                );

            return _reviewList;
        }

        public ReviewResponse Get(int id)
        {
            var review = _reviewRepository.Get(id);
            if (review == null)
                throw new ArgumentException("No match found");
            return new ReviewResponse()
            {
                Id = review.Id,
                Message = review.Message,
                MovieId = review.MovieId
            };
        }
        public int Create(ReviewRequest review)
        {
            Validations(review);
            return _reviewRepository.Add(review);
        }

        public void Update(int id, ReviewRequest review)
        {
            if (_reviewRepository.Get(id) == null)
            {
                throw new Exception("Please enter valid id of producer");
            }
            Validations(review);
            _reviewRepository.Update(id, review);
        }

        public void Delete(int id)
        {
            if (_reviewRepository.Get(id) == null)
            {
                throw new Exception("Please enter valid id of producer");
            }
            _reviewRepository.Delete(id);
        }

        private void Validations(ReviewRequest review)
        {
            if (string.IsNullOrWhiteSpace(review.Message))
            {
                throw new ArgumentNullException("Please enter valid review message");
            }
        }
    }
}

