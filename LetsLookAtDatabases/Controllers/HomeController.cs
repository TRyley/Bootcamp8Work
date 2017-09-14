using DBClasses.DBService;
using DBClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetsLookAtDatabases.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseService dbs = new DatabaseService();

        public ActionResult Index()
        {
            ViewBag.MyString = dbs.CheckConnection();

            return View();
        }

        [HttpGet]
        public ActionResult Leaderboard()
        {
            CountryMedalsViewModel cmvm = new CountryMedalsViewModel();

            cmvm = dbs.GetCountries();

            return View(cmvm);
        }

        [HttpGet]
        public ActionResult Athletes(string sort)
        {
            AthleteListViewModel alvm = new AthleteListViewModel();

            alvm = dbs.GetAndSortAthletes(sort);

            return View(alvm);
        }
    }
}