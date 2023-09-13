using DemoAPI.Classes;
using System.ComponentModel.DataAnnotations;
using static DemoAPI.Classes.SwaggerSqlEnumSchemaAttribute;

namespace DatabaseAccessDemo.Models
{
	public class ItemModel
	{
		[Required]
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }
		
		[Required]
		[SwaggerSqlEnumSchema(SqlEnumType.Type)]
		public string Type { get; set; }

		public ItemModel(Item item)
		{
			Id = item.Id;
			Name = item.Name;
			Type = item.Type;
		}
	}
}
