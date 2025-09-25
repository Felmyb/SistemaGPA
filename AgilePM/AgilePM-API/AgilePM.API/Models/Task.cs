namespace AgilePM.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public int? AssignedUserId { get; set; }
        public User? AssignedUser { get; set; }
        public int? SprintId { get; set; }
        public Sprint? Sprint { get; set; }
        public string Status { get; set; } = "ToDo";
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}