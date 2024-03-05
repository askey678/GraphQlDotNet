using GraphQL.Types;
using Sample_GraphQL.GraphqlCore;
using Sample_GraphQL.Infrastructure.Repository;
using GraphQL.MicrosoftDI;
using Sample_GraphQL.Infrastructure.DBContext;

namespace Sample_GraphQL.Helpers
{
	public static class InitHelper
	{
		public static IServiceCollection GetServices(this IServiceCollection services) {

			services.AddSingleton<SampleWebApiContext>();
			services.AddSingleton<IWebRepository, WebRepository>();
			services.AddSingleton<UserType>();
			services.AddSingleton<RoleType>();
			services.AddSingleton<UserQuery>();
			services.AddSingleton<ISchema, UserSchema>(services => new UserSchema(new SelfActivatingServiceProvider(services)));
			services.AddSingleton<UserInputType>();
			services.AddSingleton<UserMutation>();
			return services;
		}
	}
}
