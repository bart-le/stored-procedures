using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using warehouses.Models.DTO;
using warehouses.Services;

namespace warehouses.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class WarehousesController : ControllerBase
	{
		private readonly IDatabaseService _databaseService;

		public WarehousesController(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterWarehouseProductAsync(ProductDto productDto)
		{
		}
	}
}
