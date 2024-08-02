using System;
using Rest_api_Assignments.Models.DBModel;

namespace Rest_api_Assignments.Models.Request
{
	public class MovieRequest
	{
       
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<int> Actor { get; set; }
        public List<int> Genre { get; set; }
        public int ProducerId { get; set; }
        public string Image { get; set; }
    }
}

