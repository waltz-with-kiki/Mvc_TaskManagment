﻿using Microsoft.AspNetCore.Mvc;
using NewProject.DAL;
using NewProject.DAL.Interfaces;
using NewProject.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewProject.Controllers
{
    public class MainController : Controller, INotifyPropertyChanged
    {
        public MonadaMech _db;
        private readonly IRepository<User> UsersRep;
        private readonly IRepository<Exercise> ExercisesRep;
        private readonly IRepository<Project> ProjectsRep;
        private readonly IRepository<UserProject> UserProjectsRep;


        private ObservableCollection<Project> _Projects = new ObservableCollection<Project>();


        public ObservableCollection<Project> Projects
        {
            get { return _Projects; }

            set
            {
                _Projects = value;

                OnPropertyChanged(nameof(Projects));
            }
        }


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
            return View();
        }


        public IActionResult UserProjects()
        {
            //UsersRep.Add(new User { Name = "ai_land", Email = "Sqwidwq@gmail.com", Login = "ai_land", Password = "1234", Surname = "don`t know" });



           // ProjectsRep.Add(new Project { Name = "My second project", });

           // ExercisesRep.Add(new Exercise { Name = "First exercise", Header = "My first exercise", Project = ProjectsRep.Items.Where(x => x.Name == "My second project").FirstOrDefault() });
            
           // ExercisesRep.Add(new Exercise { Name = "Second exercise", Header = "My Second exercise", Project = ProjectsRep.Items.Where(x => x.Name == "My second project").FirstOrDefault() });

            Projects = new ObservableCollection<Project>(ProjectsRep.Items.ToArray());

            //ViewData["Projects"] = Projects;

            return View(Projects);
        }

         //_db.Exercises.Add(new Domain.Exercise { Name = "New Exerice" });
        // _db.SaveChanges();   



        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
