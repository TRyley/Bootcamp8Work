using DBClasses.DBRepository;
using DBClasses.Models;
using DBClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses.DBService
{
    public class DatabaseService
    {
        private DatabaseRepository db = new DatabaseRepository();
        public string CheckConnection()
        {
            return db.EstablishConnection();
        }

        public AthleteListViewModel GetAndSortAthletes(string sort)
        {
            AthleteListViewModel alvm = new AthleteListViewModel();

            List<Athlete> athletes = new List<Athlete>();

            switch (sort)
            {
                case ("countryDec"):
                    athletes = db.GetAthletes("a.country_id desc");
                    break;

                case ("ageDec"):
                    athletes = db.GetAthletes("age desc");
                    break;

                case ("nameDec"):
                    athletes = db.GetAthletes("full_name desc");
                    break;

                case ("DOBDec"):
                    athletes = db.GetAthletes("date_of_birth desc");
                    break;

                case ("sexDec"):
                    athletes = db.GetAthletes("sex desc");
                    break;
                case ("countryAsc"):
                    athletes = db.GetAthletes("a.country_id asc");
                    break;

                case ("ageAsc"):
                    athletes = db.GetAthletes("age asc");
                    break;

                case ("nameAsc"):
                    athletes = db.GetAthletes("full_name asc");
                    break;

                case ("DOBAsc"):
                    athletes = db.GetAthletes("date_of_birth asc");
                    break;

                case ("sexAsc"):
                    athletes = db.GetAthletes("sex asc");
                    break;
                default:
                    athletes = db.GetAthletes("full_name asc");
                    break;
            } // db.GetAthletes(sort);

            alvm.Athletes = athletes;

            return alvm;
        }

        public CountryMedalsViewModel GetCountries()
        {
            CountryMedalsViewModel cmvm = new CountryMedalsViewModel();


            var countryMedals = db.GetCountriesForLeaderboard();
            
            var countryList = countryMedals;

            List<string> list = new List<string>();

            foreach(var country in countryList)
            {
                if (list.IndexOf(country.CountryName) == -1)
                {
                    list.Add(country.CountryName);
                }
            }

            foreach(var country in list)
            {
                CountryMedals countries = new CountryMedals { CountryName = country};
                foreach (var countryMedal in countryMedals)
                {
                    if(countryMedal.CountryName == country)
                    {
                        countries.MedalCount += countryMedal.MedalCount;
                    }
                }

                cmvm.countryMedals.Add(countries);
            }

            cmvm.countryMedals = cmvm.countryMedals.OrderByDescending(o => o.MedalCount).ToList();

            return cmvm;
        }
    }
}
