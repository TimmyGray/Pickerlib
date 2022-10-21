
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EncryptClass;
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
           
            string encryptpass;
            using (StreamReader sr = File.OpenText("./pass.txt"))
            {
                encryptpass = sr.ReadToEnd();
            }

            string decpass = SysDecrypt.Decrypt(encryptpass);

            string connectionstring = String.Concat(conf.GetConnectionString("DefaultConnection"),$"password={decpass}");

           
            optionsBuilder.UseMySql(connectionstring, new MySqlServerVersion(new Version(5, 5, 39)));
        }

    }

    
}
