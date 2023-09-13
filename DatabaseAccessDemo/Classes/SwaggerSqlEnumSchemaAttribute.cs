using DatabaseAccessDemo.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoAPI.Classes
{

	[AttributeUsage(
		AttributeTargets.Class |
		AttributeTargets.Struct |
		AttributeTargets.Parameter |
		AttributeTargets.Property |
		AttributeTargets.Enum,
		AllowMultiple = false)]
	public class SwaggerSqlEnumSchemaAttribute : SwaggerSchemaAttribute
	{
		public SwaggerSqlEnumSchemaAttribute(SqlEnumType type)
		{
			var contextOptions = new DbContextOptionsBuilder<ApiDbContext>()
				.UseSqlServer("Name=DemoAPI")
				.Options;
			using var db = new ApiDbContext(contextOptions);

			string description = "Possible values: ";
			switch (type)
			{
				case SqlEnumType.Type:
					description += string.Join(", ", db.Types.Select(type => type.Name).ToList());
					break;
				default:
					break;
			}

			Description = description;
		}

		public enum SqlEnumType
		{
			Type
		}
	}
}
