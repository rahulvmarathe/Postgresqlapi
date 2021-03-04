using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Postgresqlapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static string Host = "pocpostgre.postgres.database.azure.com";
        private static string PostGreUser = "adminuser@pocpostgre";
        private static string DBname = "postgres";
        private static string Password = "";
        private static string Port = "5432";

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private void SqlTest()
        {
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    PostGreUser,
                    DBname,
                    Port,
                    Password);

            using (var conn = new NpgsqlConnection(connString))

            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                //using (var command = new NpgsqlCommand("DROP TABLE IF EXISTS inventory", conn))
                //{
                //    command.ExecuteNonQuery();
                //    Console.Out.WriteLine("Finished dropping table (if existed)");

                //}

                //using (var command = new NpgsqlCommand("CREATE TABLE inventory(id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER)", conn))
                //{
                //    command.ExecuteNonQuery();
                //    Console.Out.WriteLine("Finished creating table");
                //}

                //using (var command = new NpgsqlCommand("INSERT INTO inventory (name, quantity) VALUES (@n1, @q1), (@n2, @q2), (@n3, @q3)", conn))
                //{
                //    command.Parameters.AddWithValue("n1", "banana");
                //    command.Parameters.AddWithValue("q1", 150);
                //    command.Parameters.AddWithValue("n2", "orange");
                //    command.Parameters.AddWithValue("q2", 154);
                //    command.Parameters.AddWithValue("n3", "apple");
                //    command.Parameters.AddWithValue("q3", 100);

                //    int nRows = command.ExecuteNonQuery();
                //    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                //}
            }
        }

        [HttpGet]
        public string Get()
        {

            try
            {

                SqlTest();

                //var httpCLient = new HttpClient();
                //var findMyIPUrl = @"https://ipaddressapi20210302000417.azurewebsites.net/api/GetClientIPAddress?code=RzZ8dpWupbauaoTGOdA3Jp0cnlz9irXYCGJWHVLVu9pELmTia/AC7g==";
                //var ipAddress  = httpCLient.GetAsync(findMyIPUrl).Result.Content.ReadAsStringAsync().Result;
                //return ipAddress;
                //var rng = new Random();
                //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                //{
                //    Date = DateTime.Now.AddDays(index),
                //    TemperatureC = rng.Next(-20, 55),
                //    Summary = Summaries[rng.Next(Summaries.Length)]
                //})
                //.ToArray().ToString();

                return $"Hello Hello Hello ";

            }
            catch (Exception  ex)
            {
                return ex.Message;
            }

        }
    }
}
