using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DBClasses.Models;
using System.Data.SqlClient;

namespace DBClasses.DBRepository
{
    public class DatabaseRepository
    {
        private static string myConnectionString = "server=localhost;database=Olympics;uid=root;pwd=KR19tr222013;";
        private MySqlConnection cnn = new MySqlConnection(myConnectionString);
        public string EstablishConnection()
        {
            string result = "";

            try
            {
                cnn.Open();
                result = "Connection Open ! ";
                cnn.Close();
            }
            catch (Exception ex)
            {
                result = "Can not open connection ! ";
            }

            return result;
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            string query = "SELECT * FROM country";

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = cnn;
                cnn.Open();

                using (MySqlDataReader sdr = command.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        countries.Add(new Country
                        {
                            Id = Convert.ToInt32(sdr["country_id"]),
                            CountryName = sdr["country_name"].ToString(),
                            IocCountryCode = sdr["ioc_country_code"].ToString(),
                            Iso2c = sdr["iso2c"].ToString(),
                            Iso3c = sdr["iso3c"].ToString(),
                            Population = Convert.ToInt32(sdr["population"]),
                            RegionId = Convert.ToInt32(sdr["region_id"]),
                            IncomeId = Convert.ToInt32(sdr["income_id"]),
                            Latitude = Convert.ToDecimal(sdr["latitude"]),
                            Longitude = Convert.ToDecimal(sdr["longitude"])
                        });
                    }
                }
                cnn.Close();
            }

            return countries;
        }

        public List<Medal> GetMedals()
        {
            List<Medal> medals = new List<Medal>();

            string query = "SELECT * FROM medal";

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = cnn;
                cnn.Open();

                using (MySqlDataReader sdr = command.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        medals.Add(new Medal
                        {
                            Id = Convert.ToInt32(sdr["country_id"]),
                            Name = sdr["medal_name"].ToString()
                        });
                    }
                }
                cnn.Close();
            }

            return medals;
        }

        public List<AthleteMedal> GetAthleteMedals()
        {
            List<AthleteMedal> athleteMedals = new List<AthleteMedal>();

            string query = "SELECT * FROM athlete_medal";

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = cnn;
                cnn.Open();

                using (MySqlDataReader sdr = command.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        athleteMedals.Add(new AthleteMedal
                        {
                            AthleteId = Convert.ToInt32(sdr["athlete_id"]),
                            MedalId = Convert.ToInt32(sdr["medal_id"]),
                            MedalCount = Convert.ToDecimal(sdr["medal_count"]),
                        });
                    }
                }
                cnn.Close();
            }

            return athleteMedals;
        }

        public List<CountryMedals> GetCountriesForLeaderboard()
        {
            string query = "Select c.country_name, am.medal_count from country c" +
                            " join athlete a on c.country_id = a.country_id" +
                            " join athlete_medal am on am.athlete_id = a.athlete_id" +
                            " join medal m on am.medal_id = m.medal_id" +
                            " order by am.medal_count desc, c.country_name";

            List<CountryMedals> countries = new List<CountryMedals>();

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = cnn;
                cnn.Open();

                using (MySqlDataReader sdr = command.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        countries.Add(new CountryMedals
                        {
                            CountryName = sdr["country_name"].ToString(),
                            MedalCount = Convert.ToDecimal(sdr["medal_count"])
                        });
                    }
                }
                cnn.Close();
            }

            return countries;

        }

        public List<Athlete> GetAthletes(string sort)
        {
            List<Athlete> athleteMedals = new List<Athlete>();

            string query = "Select * from athlete a" +
                " join country c on c.country_id = a.country_id" +
                " join athlete_medal am on am.athlete_id = a.athlete_id" +
                " join medal m on am.medal_id = m.medal_id" +
                $" order by {sort}";

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = cnn;
                cnn.Open();

                using (MySqlDataReader sdr = command.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        athleteMedals.Add(new Athlete
                        {
                            Id = Convert.ToInt32(sdr["athlete_id"]),
                            FullName = sdr["full_name"].ToString(),
                            CountryName = (sdr["country_name"]).ToString(),
                            Age = Convert.ToInt32(sdr["age"]),
                            Sex = sdr["sex"].ToString(),
                            DOB = Convert.ToDateTime(sdr["date_of_birth"]),
                        });
                    }
                }
                cnn.Close();
            }

            return athleteMedals;
        }
    }
}
