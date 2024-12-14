namespace Main_Application.Models
{
    public class User
    {
        public Guid Id;
        public required string Name {  get; set; }

        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required Roles Role { get; set; }
        public required DateTime CreatedAt { get; set; }

    }
    public enum Roles
    {
        User,
        Administrator
    }
}
