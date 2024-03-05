using GraphQL.Types;
using Sample_GraphQL.Infrastructure.DBContext;
using Sample_GraphQL.Infrastructure.Repository;

namespace Sample_GraphQL.GraphqlCore
{
	public class RoleType : ObjectGraphType<Role>
	{
		public RoleType(IWebRepository repository)
		{

			Field(x => x.RoleKey).Description("Role Key");
			Field(x => x.RoleName).Description("Role Name");

		}
	}
}
