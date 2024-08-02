using System;
using Rest_api_Assignments.Models.DBModel;

namespace Rest_api_Assignments.Models.Response
{
	public class MovieResponse
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<Actor> Actor { get; set; }
        public List<Genre> Genre { get; set; }
        public Producer Producer { get; set; }
        public string Image { get; set; }
    }
}

