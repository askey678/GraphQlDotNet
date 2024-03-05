using Microsoft.EntityFrameworkCore;
using Sample_GraphQL.Infrastructure.DBContext;
using Sample_GraphQL.Models;

namespace Sample_GraphQL.Infrastructure.Repository
{
	public class WebRepository : IWebRepository
	{
		private readonly SampleWebApiContext _context;

		public WebRepository(SampleWebApiContext context)
		{
			this._context = context;
		}

		public async Task<User> AddUserAsync(UserViewModel user)
		{
			var userIdentityKey = Guid.NewGuid().ToString();
			var newUser = new User { UserKey = userIdentityKey, UserName = user.UserName, Email = user.Email, Password = user.Password, About = user.About, IsActive = true, IsArchived = false, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };
			var savedUser = (await _context.Users.AddAsync(newUser)).Entity;
			await _context.SaveChangesAsync();
			return savedUser;
		}

		public async Task<bool> DeleteUserAsync(User user)
		{
			user.IsArchived = true;
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<List<Role>> GetRoleInfoByUserIdAsync(string userKey)
		{
			return await (from ur in _context.UserRoles
						  join r in _context.Roles on ur.RoleKey equals r.RoleKey
						  where ur.UserKey == userKey
						  select r).ToListAsync();
		}

		public async Task<User?> GetUserByIdAsync(string userKey)
		{
			return await Task.FromResult(_context.Users.FirstOrDefault(a => a.UserKey == userKey && a.IsActive == true && a.IsArchived == false));
		}

		public async Task<User[]> GetUsersAsync()
		{
			return await _context.Users.ToArrayAsync();
		}

		public async Task<User> UpdateUserAsync(User user)
		{
			var UpdatedUser = (_context.Users.Update(user)).Entity;
			await _context.SaveChangesAsync();
			return UpdatedUser;
		}
	}
}
