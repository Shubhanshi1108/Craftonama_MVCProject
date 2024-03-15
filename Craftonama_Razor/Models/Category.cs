﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Craftonama_Razor.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }

		[MaxLength(30)]
		[Required]
		[DisplayName("Category Name")]
		public string Name { get; set; }

		[DisplayName("Display Order")]
		[Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
		public int DisplayOrder { get; set; }
	}
}
