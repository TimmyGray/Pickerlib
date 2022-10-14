
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Pickerlib.Models.Classes
{
    //[Table("phone_vote_question", Schema = "air_gatr")]
    public class Vote
    {
        [MaxLength(11)]
        public int id { get; set; }
        
        [MaxLength(45,ErrorMessage = "Превышена допустимая длина")]
        public string question { get; set; }

        [MaxLength(45, ErrorMessage = "Превышена допустимая длина")]
        public string answer1 { get; set; }
       
        [MaxLength(45, ErrorMessage = "Превышена допустимая длина")]
        public string answer2 { get; set; }
       
        public DateTime date_start { get; set; }
        public DateTime date_stop { get; set; }
        
        [MaxLength(45, ErrorMessage = "Превышена допустимая длина")]
        public string phone_number_1 { get; set; }
        
        [MaxLength(45, ErrorMessage = "Превышена допустимая длина")]
        public string phone_number_2 { get; set; }
    }
}
