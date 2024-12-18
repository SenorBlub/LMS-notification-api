﻿using Logic.IRepositories;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class NotificationRepository : INotificationRepository
{
	private readonly NotificationDbContext.NotificationDbContext _dbContext;

	public NotificationRepository(NotificationDbContext.NotificationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task CreateAsync(Notification notification)
	{
		await _dbContext.Notifications.AddAsync(notification);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(Notification notification)
	{
		var existingNotification = await _dbContext.Notifications.FindAsync(notification.Id);
		if (existingNotification == null)
		{
			throw new KeyNotFoundException("Notification not found.");
		}

		existingNotification.Title = notification.Title;
		existingNotification.PlanId = notification.PlanId;

		_dbContext.Notifications.Update(existingNotification);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(Notification notification)
	{
		_dbContext.Notifications.Remove(notification);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid notificationId)
	{
		var notification = await _dbContext.Notifications.FindAsync(notificationId);
		if (notification == null)
		{
			throw new KeyNotFoundException("Notification not found.");
		}

		_dbContext.Notifications.Remove(notification);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteByPlanAsync(Guid planId, List<Guid> notificationIds)
	{
		List<Notification> notifications = await _dbContext.Notifications
			.Where(n => notificationIds.Contains(n.Id))
			.ToListAsync();


		if (notifications.Any())
		{
			_dbContext.Notifications.RemoveRange(notifications);
			await _dbContext.SaveChangesAsync();
		}
	}

	public async Task<Notification> GetAsync(Guid notificationId)
	{
		var notification = await _dbContext.Notifications.FindAsync(notificationId);
		if (notification == null)
		{
			throw new KeyNotFoundException("Notification not found.");
		}

		return notification;
	}

	public async Task<List<Notification>> GetAllAsync(List<Guid> notificationIds)
	{
		List<Notification> notifications = await _dbContext.Notifications
			.Where(n => notificationIds.Contains(n.Id))
			.ToListAsync();
		if (notifications == null)
		{
			throw new KeyNotFoundException("Notifications not found.");
		}

		return notifications;
	}
}