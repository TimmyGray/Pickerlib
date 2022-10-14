
using System.Globalization;


namespace Pickerlib.Models.Classes
{
    public static class VoteSet
    {
        public static Vote SetValue(string question, Vote vote) //Only Question
        {
            vote.question = question;
            return vote;
        }

        public static Vote SelValue(string question, string answer1,string answer2, Vote vote) //Questino+ans1+ans2
        {
            vote.question = question;
            vote.answer1 = answer1;
            vote.answer2 = answer2;
            return vote;
        }

        public static Vote SelValue(DateTime date, Vote vote, bool start) //One Date
        {
            if (start)
            {
                vote.date_start = date;
            }

            else
            {
                vote.date_stop = date;
            }

            return vote;
        }


        public static Vote SetValue(string question,string answer1,string answer2,
                                    DateTime date_start,DateTime date_stop,Vote vote) // Question+ans1+ans2+Date1+date2
        {
            vote.question = question;
            vote.answer1=answer1; 
            vote.answer2=answer2;
            vote.date_start = date_start;
            vote.date_stop = date_stop;
            return vote;
        }

        public static Vote SetValue(string question, string answer1, string answer2,
                                    DateTime date_start, DateTime date_stop,
                                    string phone_number_1, string phone_number_2, Vote vote) //Full
        {
            vote.question = question;
            vote.answer1 = answer1;
            vote.answer2 = answer2;
            vote.date_start = date_start;
            vote.date_stop = date_stop;
            vote.phone_number_1 = phone_number_1;
            vote.phone_number_2 = phone_number_2;
            return vote;
        }

        public static Vote SetValue(DateTime date_start, DateTime date_stop, Vote vote) //Two Date
        {
            vote.date_start = date_start;
            vote.date_stop = date_stop;
            return vote;
        }

        public static Vote SetValue(string question,string answer1,string answer2,
                                    string phone_number_1, string phone_number_2, Vote vote)//question+2 ans+2 phone
        {
            vote.question = question;
            vote.answer1 = answer1;
            vote.answer2 = answer2;
            vote.phone_number_1 = phone_number_1; 
            vote.phone_number_2 = phone_number_2;
            return vote;
        }
        
        public static DateTime MakeDate(int hour, int min, int sec) //Parse Date
        {
            try
            {
                string h = "";
                string m = "";
                string s = "";
                if (hour<=9)
                {
                    h = "0";
                }
                if (min <= 9)
                {
                    m = "0";
                }
                if(sec <= 9)
                {
                    s = "0";
                }
                string parsedate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {h}{hour}:{m}{min}:{s}{sec}";
                DateTime datetime = DateTime.ParseExact(parsedate, "yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture);
                return datetime;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }


        }
    }

}
