
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EncryptClass;
using Pickerlib.Models.Classes;

namespace Pickerlib.Contexts
{
    public class VoteContext:DbContext
    {

        public DbSet<Vote> phone_vote_question { get; set; }
        readonly string decpass;


        public VoteContext() {

            try
            {
                using (StreamReader sr = File.OpenText("./pass.txt"))
                {
                    string encryptpass = sr.ReadToEnd();

                    decpass = SysDecrypt.Decrypt(encryptpass);
                    if (decpass==null)
                    {
                        throw new Exception("Ошибка в дешифровке");
                    }

                }
            }
            catch (FileNotFoundException e)
            {

                throw new Exception("Отсутсвует pass.txt");
            }
            catch (Exception)
            {
                throw new Exception("Пароль был неверно зашифрован");
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var conf = builder.Build();

            string connectionstring = String.Concat(conf.GetConnectionString("DefaultConnection"), $"password={decpass}");

            optionsBuilder.UseMySql(connectionstring, new MySqlServerVersion(new Version(5, 5, 39)));


        }

    }

    
}
