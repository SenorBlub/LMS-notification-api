using Logic.Models;

namespace Logic.IServices;

public interface INotificationService
{
	public Task CreateAsync(Notification notification);
	public Task DeleteAsync(Guid notificationId);
	public Task DeleteAsync(Notification notification);
	public Task DeleteByPlanAsync(Guid planId, Guid userId);
	public Task<Notification> GetAsync(Guid notificationId);
	public Task<List<Notification>> GetAllAsync(Guid userId);
	public Task UpdateAsync(Notification notification);
}