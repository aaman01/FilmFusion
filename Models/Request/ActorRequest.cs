using System;
namespace Rest_api_Assignments.Models.Request
{
	public class ActorRequest
	{
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
    }
}

//{
//    "Name":"Dark Knights",
//    "YearOfRelease":2010,
//    "Plot":"Batman crime",
//    "ProducerId":1,
//    "Image":"sd",
//    "Actor":["1","2"],
//    "Genre":["1"]
    
//}