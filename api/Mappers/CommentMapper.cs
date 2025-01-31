using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.comment;
using api.Models;

namespace api.Mappers
{
	public static class CommentMapper
	{
		public static CommentDto ToCommentDto (this Comment comment)
		{
			return new CommentDto
			{
				Id = comment.Id,
				Title = comment.Title,
				content = comment.content,
				createDate = comment.createDate,
				StockID = comment.StockID
			};
		}
		
		public static Comment ToCommenFromtcreate (this CreatCommentDTO comment, int stockID)
		{
			return new Comment
			{
				Title = comment.Title,
				content = comment.content,
				StockID = stockID
			};
		}
		
	}
}