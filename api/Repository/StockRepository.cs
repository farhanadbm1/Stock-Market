using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
	public class StockRepository : IStockRepository
	{
		private readonly ApplicationDBContext _context;

		public StockRepository(ApplicationDBContext context)
		{
			_context = context;
		}

		public async Task<Stock> CreateAsync(Stock stockModel)
		{
			await _context.Stocks.AddAsync(stockModel);
			await _context.SaveChangesAsync();
			return stockModel;
		}

		public async Task<Stock> DeleteAsync(int id)
		{
			var stock = await _context.Stocks.FindAsync(id);
			if (stock == null)
			{
				return null;
			}
			_context.Stocks.Remove(stock);
			await _context.SaveChangesAsync();
			return stock;
		}

		public async Task<List<Stock>> GetAllAsync()
		{
			return await _context.Stocks.Include(c=>c.Coments).ToListAsync();
		}

		public async Task<Stock> GetByIdAsync(int id)
		{
			return await _context.Stocks.Include(c => c.Coments).FirstOrDefaultAsync(s => s.Id == id);
		}

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(e => e.Id == id);
        }

        public async Task<Stock> UpdateAsync(int id, UpdateRequestDTO stockDto)
		{
			
			var existingStock = await _context.Stocks.FindAsync(id);
			if (existingStock == null)
			{
				return null;
			}
			existingStock.Sysmbol = stockDto.Sysmbol;
			existingStock.CompanyName = stockDto.CompanyName;
			existingStock.Purchash = stockDto.Purchash;
			existingStock.devident = stockDto.devident;
			existingStock.Industry = stockDto.Industry;
			existingStock.marketcap = stockDto.marketcap;
			await _context.SaveChangesAsync();
			return existingStock;

		}
	}
}