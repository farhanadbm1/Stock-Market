using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
	public class Stock
	{  
		public int Id { get; set; }
		public string Sysmbol { get; set; } = string.Empty;
		public string CompanyName { get; set; } = string.Empty;
		[Column(TypeName = "decimal(18,2)")]
		public decimal Purchash { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal devident { get; set; }
		public string Industry { get; set; } = string.Empty;
		public long marketcap { get; set; }

		public List<Comment> Coments { get; set; } = new List<Comment>();
		
		
	}
		
}