using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using api.Dtos.comment;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IcommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(IcommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepo = commentRepository;
            _stockRepo = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{StockID}")]
        public async Task<IActionResult> Create(int StockID, [FromBody] CreatCommentDTO commentDTO)
        {
            if (!await _stockRepo.StockExists(StockID))
            {
                return NotFound();
            }
            var comment = commentDTO.ToCommenFromtcreate(StockID);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = comment.Id }, comment.ToCommentDto());
        }
    }
}