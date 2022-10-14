
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Options;
using Pickerlib.Models.Classes;

namespace Pickerlib.Contexts
{
    public class VoteContext:DbContext
    {

        public DbSet<Vote> phone_vote_question { get; set; }


        public VoteContext() {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var conf = builder.Build();
            string connectionstring = conf.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionstring, new MySqlServerVersion(new Version(5, 5, 39)));
        }

    }

    
}
