using GraphQL;
using GraphQL.Types;
using Sample_GraphQL.Infrastructure.Repository;
using Sample_GraphQL.Models;
using System.Linq.Expressions;

namespace Sample_GraphQL.GraphqlCore
{
	public class UserMutation : ObjectGraphType<object>
	{
		public UserMutation(IWebRepository repository)
		{

			Name = "UserMutation";

			FieldAsync<UserType>(
				"createUser",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<UserInputType>> { Name = "userInput" }
					),
				resolve: async context =>
				{
					var userDataInput = context.GetArgument<UserViewModel>("userInput");
					return await repository.AddUserAsync(userDataInput);
				}
				);

			FieldAsync<UserType>(
				"updateUser",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<UserInputType>> { Name = "userInput"},
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userKey"}),
				resolve: async context =>
				{
					var userDataInput = context.GetArgument<UserViewModel>("userInput");
					var userKey = context.GetArgument<string>("UserKey");

					if (string.IsNullOrWhiteSpace(userKey))
					{
						context.Errors.Add(new ExecutionError("UserKey is Null, Please Try Again!"));
						return null;
					}

					var userInfoRetrieved = await repository.GetUserByIdAsync(userKey);
					if(userInfoRetrieved == null)
					{
						context.Errors.Add(new ExecutionError("Couldn't Find User with given Key!!"));
						return null;
					}
					userInfoRetrieved.Email = userDataInput.Email;
					userInfoRetrieved.Password = userDataInput.Password;
					userInfoRetrieved.About = userDataInput.About;
					userInfoRetrieved.UserName = userDataInput.UserName;
					userInfoRetrieved.DateUpdated = DateTime.Now;

					return await repository.UpdateUserAsync(userInfoRetrieved);
				});

			FieldAsync<StringGraphType>(
				"deleteUser",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "UserKey" }),
				resolve: async context =>
				{
					var userKey = context.GetArgument<string>("userKey");

					if (string.IsNullOrWhiteSpace(userKey))
					{
						context.Errors.Add(new ExecutionError("UserKey is Null, Please Try Again!"));
						return null;
					}

					var userInfoRetrieved = await repository.GetUserByIdAsync(userKey);
					if(userInfoRetrieved == null)
					{
						context.Errors.Add(new ExecutionError("Couldn't Find User with given Key!!"));
						return null;
					}
					await repository.DeleteUserAsync(userInfoRetrieved);
					return $" User with userKey {userKey} and userName {userInfoRetrieved.UserName} has been deleted successfully";
				});

		}
	}
}
