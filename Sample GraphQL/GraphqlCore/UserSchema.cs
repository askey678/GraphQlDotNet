using GraphQL.Types;

namespace Sample_GraphQL.GraphqlCore
{
	public class UserSchema : Schema
	{
		public UserSchema(IServiceProvider service) : base(service) {
		
			Query = service.GetRequiredService<UserQuery>();
			Mutation = service.GetRequiredService<UserMutation>();
			
		}
	}
}
