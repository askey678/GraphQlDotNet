using GraphQL.Types;

namespace Sample_GraphQL.GraphqlCore
{
	public class UserInputType : InputObjectGraphType
	{
		public UserInputType()
		{

			Name = "AddUserInput";
			Field<NonNullGraphType<StringGraphType>>("UserName");
			Field<NonNullGraphType<StringGraphType>>("Email");
			Field<NonNullGraphType<StringGraphType>>("Password");
			Field<StringGraphType>("About");

		}
	}
}
