using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateRequestDTO
    {
        public string Sysmbol { get; set; } = string.Empty;
		public string CompanyName { get; set; } = string.Empty;
		public decimal Purchash { get; set; }
		public decimal devident { get; set; }
		public string Industry { get; set; } = string.Empty;
		public long marketcap { get; set; }
    }
}