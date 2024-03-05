using GraphQL.Types;
using GraphQL.Server;
using Sample_GraphQL.Helpers;

namespace Sample_GraphQL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.GetServices();

			// register graphQL
			builder.Services.AddGraphQL(options =>
			{
				options.EnableMetrics = true;
			}).AddSystemTextJson();

			builder.Services.AddControllers();

			var conString = builder.Configuration.GetSection("ConnectionString:DBConnection");
			
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new() { Title = "Sample-GraphQLDotNet", Version = "v1" });
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample-GraphQLDotNet v1"));
				// add altair UI to development only
				app.UseGraphQLAltair();

			
			}


			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();
			app.UseGraphQL<ISchema>();
			app.Run();
		}
	}
}
