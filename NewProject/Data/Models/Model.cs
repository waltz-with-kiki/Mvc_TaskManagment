

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NewProject.Data.Models
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

        [Required]
        public string? Password { get; set; }

        public string? Email { get; set; }

        public ICollection<Task>? Tasks { get; set; }

        public ICollection<UserProject>? UserProjects { get; set; }

    }

    public enum StatusType
    {
        Processing,
        Completed,
        Waiting
    }

    public class Task : NamedEntity
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

        public ICollection<Task>? Tasks { get; set; }

    }

    public class UserProject : Entity
    {
        public User? User { get; set; }

        public Project? Project { get; set; }

    }

    public class MonadaMech : DbContext
    {

       public DbSet<User> Users { get; set; }

       public  DbSet<Project> Projects { get; set; }

       public DbSet<Task> Tasks { get; set; }

       public DbSet<UserProject> UserProject { get; set; }


        public MonadaMech(DbContextOptions<MonadaMech> options) : base(options)
        {

        }

    }



}
