﻿using System;
namespace Rest_api_Assignments.Models.DBModel
{
	public class Movie
	{
		public int  Id { get; set; }
		public string Name { get; set; }
		public int YearOfRelease { get; set; }
		public string Plot { get; set; }
		public int ProducerId { get; set; }
		public string Image { get; set; }


	}
}

