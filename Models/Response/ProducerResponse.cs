﻿using System;
namespace Rest_api_Assignments.Models.Response
{
	public class ProducerResponse
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
    }
}
