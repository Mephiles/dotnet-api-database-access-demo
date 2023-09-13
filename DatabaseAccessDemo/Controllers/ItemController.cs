using DatabaseAccessDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAccessDemo.Controllers
{
	[ApiController]
	[Route("items")]
	public class ItemController : ControllerBase
	{

		protected readonly ApiDbContext DB;

		public ItemController(IServiceScopeFactory serviceScopeFactory)
		{
			var scope = serviceScopeFactory.CreateScope();
			DB = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
		}

		[HttpGet]
		[ProducesResponseType(typeof(ItemModel), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
		public ActionResult<ItemModel> GetOne(int id)
		{
			Item? item = DB.Items.Find(id);

			if (item != null)
			{
				return NotFound(new { });
			}

			return Ok(item);
		}

	}
}
