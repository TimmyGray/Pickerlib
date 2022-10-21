using Pickerlib.Models;
using Pickerlib.Models.Classes;

namespace Pickerlib.Contexts
{
    public static class SaveDataContext
    {
        private static readonly string correct = "Успешно добавлено";
        private static readonly string incorrect = "Заполните все поля";
        private static readonly string noconn = "Нет подключения";
        private static readonly string incorrectdate = "Неправильно задан интервал времени";

        #region check connection
        public static bool CheckConn()
        
        {
            using (VoteContext db = new VoteContext())
            {
                try
                {
                    var test = db.phone_vote_question.Any();
                    return true;
                }
                catch (Exception e)
                {

                   return false;
                }
            }
            
        }
        #endregion

        #region save question
        public static string SaveData(string question)
        {
            if (!CheckConn())
            {
                return noconn;
            }
           
            if (question!=null && question != "")
            {
                
                using (VoteContext db = new VoteContext())
                {
                   
                    db.phone_vote_question.Add(VoteSet.SetValue(question,new Vote()));
                    db.SaveChanges();
                    
                }
                return correct;
            }
            return incorrect;
        }

        #endregion

        #region save question + 2 ans
        public static string SaveData(string question, string ans1, string ans2)
        {
            if (!CheckConn())
            {
                return noconn;
            }

            if (question!=null && question!=""
                && ans1 != null && ans1 !=""
                && ans2 != null && ans2 !="")
            {

                using (VoteContext db = new VoteContext())
                {

                    db.phone_vote_question.Add(VoteSet.SetValue(question, ans1, ans2, new Vote()));
                    db.SaveChanges();
                    
                }

                return correct;

            }

            return incorrect;

        }
        #endregion

        #region save one date
        public static string SaveData(ITimeItem hour,ITimeItem min, ITimeItem sec, bool start)
        {

            if (!CheckConn())
            {
                return noconn;
            }

            try
            {
                DateTime date = VoteSet.MakeDate(hour.Clockvalue, min.Clockvalue, sec.Clockvalue);


                if (start)
                {


                    using (VoteContext db = new VoteContext())
                    {

                        db.phone_vote_question.Add(VoteSet.SetValue(date, new Vote(), start));
                        db.SaveChanges();
                        

                    }

                    return correct;

                }
                else if (!start)
                {

                    using (VoteContext db = new VoteContext())
                    {

                        db.phone_vote_question.Add(VoteSet.SetValue(date, new Vote(), start));
                        db.SaveChanges();
                        

                    }

                    return correct;

                }
            }
            catch (Exception e)
            {

                return $"{e.Message}\n{e.InnerException.Message}\n{e.StackTrace}";
            }

           

            return incorrect;
        }
        #endregion

        #region save two dates
        public static string SaveData(ITimeItem hour1, ITimeItem min1, ITimeItem sec1, ITimeItem hour2, ITimeItem min2, ITimeItem sec2)
        {

            if (!CheckConn())
            {
                return noconn;
            }

            if (hour1 != null
                   && min1 != null
                   && sec1 != null
                   && hour2 != null
                   && min2 != null
                   && sec2 != null)
            {
                try
                {
                    DateTime date1 = VoteSet.MakeDate(hour1.Clockvalue, min1.Clockvalue, sec1.Clockvalue);
                    DateTime date2 = VoteSet.MakeDate(hour2.Clockvalue, min2.Clockvalue, sec2.Clockvalue);
                    if (date1>=date2)
                    {
                        return incorrectdate;
                    }
                    using (VoteContext db = new VoteContext())
                    {
                        db.phone_vote_question.Add(VoteSet.SetValue(date1, date2, new Vote()));
                        db.SaveChanges();

                    }
                    return correct;
                }
                catch (Exception e)
                {

                    return $"{e.Message}\n{e.InnerException.Message}\n{e.StackTrace}";
                }

            }


            return incorrect;
        }
        #endregion

        #region save question+2ans+2phone
        public static string SaveData(string question, string ans1, string ans2, string phone1, string phone2)
        {

            if (!CheckConn())
            {
                return noconn;
            }

            if (question != null && question != ""
                && ans1 != null && ans1 != ""
                && ans2 != null && ans2 != ""
                && phone1 != null && phone1 != ""
                && phone2 != null && phone2 != "")
            {

                using (VoteContext db = new VoteContext())
                {

                    db.phone_vote_question.Add(VoteSet.SetValue(question, ans1, ans2, phone1, phone2, new Vote()));
                    db.SaveChanges();
                    
                }
                return correct;

            }
            return incorrect;
        }
        #endregion

        #region save full
        public static string SaveData(string question, string ans1, string ans2,
                                        ITimeItem hour1, ITimeItem min1, ITimeItem sec1,
                                        ITimeItem hour2, ITimeItem min2, ITimeItem sec2,
                                        string phone1, string phone2)
        {
            

            if (!CheckConn())
            {
                return noconn;
            }

            if (question != null && question != ""
                && ans1 != null && ans1 != ""
                && ans2 != null && ans2 != ""
                && phone1 != null && phone1 != ""
                && phone2 != null && phone2 != ""
                && hour1 != null && min1 != null
                && sec1 != null && hour2 != null
                && min2 != null && sec2 != null)
            {
                
                try
                {
                    DateTime date1 = VoteSet.MakeDate(hour1.Clockvalue, min1.Clockvalue, sec1.Clockvalue);
                    DateTime date2 = VoteSet.MakeDate(hour2.Clockvalue, min2.Clockvalue, sec2.Clockvalue);
                    if (date1 >= date2)
                    {
                        return incorrectdate;
                    }
                    using (VoteContext db = new VoteContext())
                    {

                        db.phone_vote_question.Add(VoteSet.SetValue(question, ans1, ans2, date1, date2, phone1, phone2, new Vote()));
                        db.SaveChanges();


                    }
                    return correct;

                }
                catch (Exception e)
                {

                    return $"{e.Message}\n{e.InnerException.Message}\n{e.StackTrace}";
                }
               

            }


            return incorrect;
        }
        #endregion
    }

}
