using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
	public class CommentRepository : IcommentRepository
	{
		public readonly ApplicationDBContext _context;
		public CommentRepository(ApplicationDBContext context) 
		{
			_context = context;
		}

		public async Task<Comment> CreateAsync(Comment comment)
		{
			await _context.Comments.AddAsync(comment);
			await _context.SaveChangesAsync();
			return comment;
		}

		public async Task<List<Comment>> GetAllAsync()
		{
			return await _context.Comments.ToListAsync();
		}

		

		async Task<Comment> IcommentRepository.GetByIdAsync(int id)
		{
			return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
		}
	}
}