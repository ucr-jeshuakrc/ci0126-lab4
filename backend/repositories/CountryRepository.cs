using backend.Models;
using Dapper;
using Microsoft.Data.SqlClient;
namespace backend.Repositories
{
    public class CountryRepository {
        private readonly string _connectionString;

        public CountryRepository() {
            var builder = WebApplication.CreateBuilder();
            _connectionString = builder.Configuration.GetConnectionString("CountryContext") ?? throw new InvalidOperationException("CountryContext connection string not found.");
        }
        
        public List<CountryModel> GetCountries() {
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM dbo.Country";
            return connection.Query<CountryModel>(query).ToList();
        }

        public bool CreateCountry(CountryModel country) {
            using var connection = new SqlConnection(_connectionString);
            var query = @"INSERT INTO [dbo].[Country]([Name],[Language],[Continent]) VALUES (@Name, @Language, @Continent)";
            var affectedRows = connection.Execute(query, new {
                Name = country.Name,
                Language = country.Language,
                Continent = country.Continent
            });
            return affectedRows >= 1;
        }
    }
}