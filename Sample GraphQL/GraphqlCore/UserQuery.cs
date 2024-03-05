using GraphQL;
using GraphQL.Types;
using Sample_GraphQL.Infrastructure.Repository;

namespace Sample_GraphQL.GraphqlCore
{
	public class UserQuery : ObjectGraphType<object>
	{
		public UserQuery(IWebRepository repository)
		{
			Name = "UserQuery";

			Field<UserType>(
				"user",
				arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "UserKey" }),
				resolve: context =>
				{

					var userKey = context.GetArgument<string>("UserKey");

					if (string.IsNullOrWhiteSpace(userKey))
					{
						context.Errors.Add(new ExecutionError("UserKey is Null, Please Try Again!"));
						return null;
					}
					return repository.GetUserByIdAsync(userKey);
				});

			Field<ListGraphType<UserType>>(
				"users",
				resolve: context => repository.GetUsersAsync()
				);
		}
	}
}
