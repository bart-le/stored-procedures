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
			try
			{
				using SqlConnection connection = GetSqlConnection();
				var command = new SqlCommand(
					@"SELECT TOP 1 * FROM ""Order"" " +
					"WHERE IdProduct = @idProduct " +
					"AND Amount = @amount " +
					"AND CreatedAt < @createdAt",
					connection
				);

				command.Parameters.AddWithValue("@idProduct", idProduct);
				command.Parameters.AddWithValue("@amount", amount);
				command.Parameters.AddWithValue("@createdAt", createdAt);
				await connection.OpenAsync();

				var reader = await command.ExecuteReaderAsync();

				await reader.ReadAsync();

				return new()
				{
					IdOrder = Convert.ToInt32(reader["IdOrder"]),
					IdProduct = Convert.ToInt32(reader["IdProduct"]),
					Amount = Convert.ToInt32(reader["Amount"]),
					CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
					FulfilledAt = Convert.ToDateTime(reader["CreatedAt"])
				};
			}
			catch (Exception)
			{
				return null;
			}
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
