namespace Logic.Models;

public class Notification
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public Guid PlanId { get; set; }
	public Guid UserId { get; set; }
}