using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.comment
{
    public class CreatCommentDTO
    {
            public string Title { get; set; } = string.Empty;
			public string content { get; set; } = string.Empty;

        
    }
}