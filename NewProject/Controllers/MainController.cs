using Microsoft.AspNetCore.Mvc;
using NewProject.DAL;
using NewProject.DAL.Interfaces;
using NewProject.Domain;

namespace NewProject.Controllers
{
    public class MainController : Controller
    {
        public MonadaMech _db;
        private readonly IRepository<User> UsersRep;
        private readonly IRepository<Exercise> ExercisesRep;
        private readonly IRepository<Project> ProjectsRep;
        private readonly IRepository<UserProject> UserProjectsRep;



        public MainController(MonadaMech db, IRepository<User> users, IRepository<Exercise> exercises, IRepository<Project> projects, IRepository<UserProject> userprojects)
        {
            _db = db;
            UsersRep = users;
            ExercisesRep = exercises;
            ProjectsRep = projects;
            UserProjectsRep = userprojects;
        }


        public IActionResult Index()
        {
            // _db.Exercises.Add(new Domain.Exercise { Name = "New Exerice" });
            // _db.SaveChanges();
            UsersRep.Add(new User { Login = "Charm", Password = "1234", Email = "USER@gmail.com" });
            ExercisesRep.Add(new Exercise { Name = "FirstExercise", Header = "Check" });
            ProjectsRep.Add(new Project { Name = "FirstProject", Author = UsersRep.Items.Where(i => i.Login == "Charm").FirstOrDefault() });
            return View();
        }
    }
}
