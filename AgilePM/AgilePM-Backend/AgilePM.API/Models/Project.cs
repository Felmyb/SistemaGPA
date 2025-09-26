namespace AgilePM.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Sprint>? Sprints { get; set; }
    }
}