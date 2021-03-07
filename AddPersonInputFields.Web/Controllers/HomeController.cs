using AddPersonInputFields.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AddPersonInputFields.Data;

namespace AddPersonInputFields.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
               @"Data Source=.\sqlexpress; Initial Catalog=People;Integrated Security=true;";
        public IActionResult Index()
        {
            PeopleDb db = new(_connectionString);
            PeopleViewModel vm = new PeopleViewModel()
            {
                People = db.GetPeople()
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult AddPeople(int fields)
        {
            return View();
        }
        public IActionResult SubmitPeople(List<Person> people)
        {
            PeopleDb db = new(_connectionString);
            db.AddPeople(people);
            TempData["message"] = "People added successfully!";
            return Redirect("/home/index");
        }
    }
}
