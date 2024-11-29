using Logic.IRepositories;
using Logic.IServices;
using Logic.Models;

namespace Logic.Services;

public class NotificationService : INotificationService
{
	private readonly INotificationRepository _notificationRepository;

	public NotificationService(INotificationRepository notificationRepository)
	{
		_notificationRepository = notificationRepository;
	}
	public async Task CreateAsync(Notification notification)
	{
		await _notificationRepository.CreateAsync(notification);
	}

	public async Task DeleteAsync(Guid notificationId)
	{
		await _notificationRepository.DeleteAsync(notificationId);
	}

	public async Task DeleteAsync(Notification notification)
	{
		await _notificationRepository.DeleteAsync(notification);
	}

	public async Task DeleteByPlanAsync(Guid planId, Guid userId)
	{
		await _notificationRepository.DeleteByPlanAsync(planId, userId);
	}

	public async Task<Notification> GetAsync(Guid notificationId)
	{
		return await _notificationRepository.GetAsync(notificationId);
	}

	public async Task<List<Notification>> GetAllAsync(Guid userId)
	{
		return await _notificationRepository.GetAllAsync(userId);
	}

	public async Task UpdateAsync(Notification notification)
	{
		await _notificationRepository.UpdateAsync(notification);
	}
}