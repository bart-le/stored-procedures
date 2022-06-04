using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using warehouses.Models;
using warehouses.Models.DTO;

namespace warehouses.Services
{
	public class WarehousesDatabaseService : IDatabaseService
	{
		private readonly IConfiguration _configuration;

		public WarehousesDatabaseService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<bool> ProductExistsAsync(int idProduct)
		{
			using SqlConnection connection = GetSqlConnection();
			var command = new SqlCommand(
				"SELECT 1 FROM Product WHERE IdProduct = @idProduct",
				connection
			);

			command.Parameters.AddWithValue("@idProduct", idProduct);
			await connection.OpenAsync();

			var result = await command.ExecuteReaderAsync();

			return result.HasRows;
		}

		public async Task<Order> GetOrderAsync(int idProduct, int amount, DateTime createdAt)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> OrderCompletedAsync(int idOrder)
		{
			throw new NotImplementedException();
		}

		public async Task CompleteOrderAsync(int idOrder)
		{
			throw new NotImplementedException();
		}

		public async Task<int> RegisterWarehouseProductAsync(ProductDto productDto)
		{
			throw new NotImplementedException();
		}

		private SqlConnection GetSqlConnection()
		{
			return new(_configuration.GetConnectionString("DefaultDatabaseConnection"));
		}
	}
}
