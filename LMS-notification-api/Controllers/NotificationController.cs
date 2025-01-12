using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.IServices;
using Logic.Models;

namespace LMS_notification_api.Controllers
{
	[Route("notification/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create([FromBody] Notification notification)
		{
			await _notificationService.CreateAsync(notification);
			return Ok(notification);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var notification = await _notificationService.GetAsync(id);
			if (notification == null)
				return NotFound();
			return Ok(notification);
		}

		[HttpGet("user/{userId}")]
		public async Task<IActionResult> GetAll(Guid userId)
		{
			var notifications = await _notificationService.GetAllAsync(userId);
			return Ok(notifications);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] Notification notification)
		{
			if (id != notification.Id)
				return BadRequest();

			await _notificationService.UpdateAsync(notification);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _notificationService.DeleteAsync(id);
			return NoContent();
		}

		[HttpDelete("plan/{planId}/user/{userId}")]
		public async Task<IActionResult> DeleteByPlan(Guid planId, Guid userId)
		{
			await _notificationService.DeleteByPlanAsync(planId, userId);
			return NoContent();
		}
	}
}
