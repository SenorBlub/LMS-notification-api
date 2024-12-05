using Logic.Models;

namespace Logic.IRepositories;

public interface INotificationRepository
{
	public Task CreateAsync(Notification notification);
	public Task UpdateAsync(Notification notification);
	public Task DeleteAsync(Notification notification);
	public Task DeleteAsync(Guid notificationId);
	public Task DeleteByPlanAsync(Guid planId, List<Guid> notificationIds);
	public Task<Notification> GetAsync(Guid notificationId);
	public Task<List<Notification>> GetAllAsync(List<Guid> notificationIds);
}