using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using api.Dtos.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;


namespace api.Controllers
{
	[Route("api/stock")]
	[ApiController]
	public class StockController :ControllerBase
	{
		private readonly ApplicationDBContext _context;

	 private readonly IStockRepository _stockrepo;

		public StockController(ApplicationDBContext context, IStockRepository stockrepo)
		{
			_context = context;
			_stockrepo = stockrepo;
		}

		
		[HttpGet]
		public async Task<IActionResult> GetAllasync()
		{
			var stocks = await _stockrepo.GetAllAsync();
			var stockDto= stocks.Select(S => S.ToStockDto());
			return Ok(stocks);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByID([FromRoute]int id)
		{
			var stock = await _stockrepo.GetByIdAsync(id);
			if (stock == null)
			{
				return NotFound();
			}
			return Ok(stock.ToStockDto());
		}
		
		[HttpPost]
		
		public async Task<IActionResult> Create([FromBody]CreateStockRequestDto stockDto)
		{
			var stockModel = stockDto.ToStockFromCeateDTO();
			
			await _stockrepo.CreateAsync(stockModel);
			return CreatedAtAction(nameof(GetByID), new {id = stockModel.Id}, stockModel.ToStockDto());
		}
		[HttpPut]
		[Route("{id}")]
		public async Task <IActionResult> Update([FromRoute]int id, [FromBody] UpdateRequestDTO updateDTO)
		{
			var stockModel =await _stockrepo.UpdateAsync(id, updateDTO);	
			if (stockModel == null)
			{
				return NotFound();
			}

			return Ok(stockModel.ToStockDto());
		}
		[HttpDelete]
		[Route("{id}")]
		public  async Task<ActionResult>  Delete([FromRoute]int id)
		{
			var stockModel = await _stockrepo.DeleteAsync(id);
			if (stockModel == null)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}