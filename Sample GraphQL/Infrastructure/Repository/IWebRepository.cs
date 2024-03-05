using Sample_GraphQL.Infrastructure.DBContext;
using Sample_GraphQL.Models;

namespace Sample_GraphQL.Infrastructure.Repository
{
	public interface IWebRepository
	{
		Task<User[]> GetUsersAsync();
		Task<User?> GetUserByIdAsync(string userKey);
		Task<List<Role>> GetRoleInfoByUserIdAsync(string userKey);
		Task<User> AddUserAsync(UserViewModel user);
		Task<User> UpdateUserAsync(User user);
		Task<bool> DeleteUserAsync(User user);
	}
}
