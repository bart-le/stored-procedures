using System;
using System.Threading.Tasks;
using warehouses.Models;
using warehouses.Models.DTO;

namespace warehouses.Services
{
	public interface IDatabaseService
	{
		Task<bool> ProductExistsAsync(int idProduct);
		Task<Order> GetOrderAsync(int idProduct, int amount, DateTime createdAt);
		Task<bool> IsOrderCompletedAsync(Order order);
		Task<Order> CompleteOrderAsync(int idOrder);
		Task<int> RegisterWarehouseProductAsync(int idOrder, ProductDto productDto);
	}
}
