using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models; // Assuming Stock is defined in the Models namespace

namespace api.Mappers
{
	public static class StockMappers
	{
		public static StockDto ToStockDto(this Stock stockModel)
		{
			return new StockDto
			{
				Id = stockModel.Id,
				Sysmbol = stockModel.Sysmbol,
				CompanyName = stockModel.CompanyName,
				Purchash = stockModel.Purchash,
				devident = stockModel.devident,
				Industry = stockModel.Industry,
				marketcap = stockModel.marketcap,
				Comments = stockModel.Coments.Select(c => c.ToCommentDto()).ToList()
			};
		}
		
		public static Stock ToStockFromCeateDTO(this CreateStockRequestDto createStockRequestDto)
		{
			return new Stock
			{
				Sysmbol = createStockRequestDto.Sysmbol,
				CompanyName = createStockRequestDto.CompanyName,
				Purchash = createStockRequestDto.Purchash,
				devident = createStockRequestDto.devident,
				Industry = createStockRequestDto.Industry,
				marketcap = createStockRequestDto.marketcap
			};
		}
	}
}