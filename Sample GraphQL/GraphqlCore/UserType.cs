using GraphQL.Types;
using Sample_GraphQL.Infrastructure.DBContext;
using Sample_GraphQL.Infrastructure.Repository;

namespace Sample_GraphQL.GraphqlCore
{
	public class UserType : ObjectGraphType<User>
	{
		public UserType(IWebRepository repository)
		{

			Field(x => x.UserKey).Description("User Key");
			Field(x => x.About).Description("About");
			Field(x => x.UserName).Description("User Name");
			Field(x => x.Email).Description("User Email");

			//Field<ListGraphType<RoleType>> (Name, Arguments, Resolve Func)
			Field<ListGraphType<RoleType>>("Role",
				arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "UserKey" }),
				resolve: context => repository.GetRoleInfoByUserIdAsync(context.Source.UserKey)
				);
		}
	}
}
