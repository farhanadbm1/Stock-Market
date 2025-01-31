using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string content { get; set; } = string.Empty;
		public DateTime createDate { get; set; } = DateTime.Now;
		public int? StockID { get; set; }
		public Stock? stock { get; set; }
		
	}
}