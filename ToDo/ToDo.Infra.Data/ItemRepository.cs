using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;

namespace ToDo.Infra.Data
{

	public class ItemRepository : IITemRepository
	{
		private readonly string connectionString;
		public ItemRepository(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("ToDoDb");
		}
		public async Task AddAsync(Item item)
		{
			var query = "INSERT INTO items(Id, Description, Done, CreatedAt) VALUES(@Id, @Description, @Done, @CreatedAt)";
			using (var conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					await conn.ExecuteAsync(query, item);
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					conn.Close();
				}
			}
		}

		public async Task<IEnumerable<Item>> GetAllAsync()
		{
			IEnumerable<Item> result;
			var query = "SELECT * FROM items";
			using (var conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					result = await conn.QueryAsync<Item>(query);
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					conn.Close();
				}
			}
			return result;
		}

		public async Task EditAsync(Guid id, string description, bool done)
		{
			var count = 0;
			var query = "UPDATE Items SET Description = @Description, Done = @Done WHERE id = @Id";
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					count = await con.ExecuteAsync(query, new { Description = description,Done = done, Id = id });
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					con.Close();
				}
			};
		}

		public async Task ExcludeAsync(Guid id)
		{

			var query = "DELETE FROM items where id = @Id";
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					await con.ExecuteAsync(query, new { Id  = id} );
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					con.Close();
				}
			};
		}
	}
}
