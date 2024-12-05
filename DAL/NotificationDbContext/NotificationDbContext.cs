using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.NotificationDbContext;

public class NotificationDbContext : DbContext
{
	public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
	{
	}

	public DbSet<Notification> Notifications { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Notification>(entity =>
		{
			entity.HasKey(n => n.Id);

			entity.Property(n => n.Title)
				.IsRequired()
				.HasMaxLength(255);

			entity.Property(n => n.PlanId)
				.IsRequired();
		});
	}
}