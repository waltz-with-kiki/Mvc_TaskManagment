using System.ComponentModel.DataAnnotations;

namespace NewProject.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }

    }

    public abstract class NamedEntity : Entity
    {
        public string? Name { get; set; }
    }

    public abstract class Person : NamedEntity
    {
        public string? Surname { get; set; }
    }


    public class User : Person
    {
        [Required]
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public ICollection<Exercise>? Exercises { get; set; }

        public ICollection<UserProject>? UserProjects { get; set; }

    }

    public enum StatusType
    {
        Processing,
        Completed,
        Waiting
    }

    public class Exercise : NamedEntity
    {
        public string? Header { get; set; }

        public string? Description { get; set; }

        public StatusType Status { get; set; }

        public DateTime Deadline { get; set; }

        public User? User { get; set; }

        public Project? Project { get; set; }

    }


    public class Project : NamedEntity
    {

        public string? Presentation { get; set; }

        public User? Author { get; set; }


        public ICollection<UserProject>? ProjectUsers { get; set; }

        public ICollection<Exercise>? Exercises { get; set; }

    }

    public class UserProject : Entity
    {
        public User? User { get; set; }

        public Project? Project { get; set; }

    }
}