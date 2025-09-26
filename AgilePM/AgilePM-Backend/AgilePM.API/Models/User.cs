namespace AgilePM.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Role { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Task>? Tasks { get; set; }
    }
}