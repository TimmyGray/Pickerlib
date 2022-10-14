using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pickerlib.Models.Classes;

namespace Pickerlib.Contexts
{
    public static class SaveDataContext
    {
        private static readonly string correct = "Заполните все поля";
        private static readonly string incorrect = "Заполните все поля";

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
                catch (Exception)
                {

                    return false;
                }
            }
            
        }
        #endregion

       
        #region save question
        public static string SaveData(string question)
        {
            if (question!=null||question=="")
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
            if (question!=null||question==""
                && ans1 != null|| ans1 !=""
                && ans2 != null || ans2 !="")
            {

                using (VoteContext db = new VoteContext())
                {

                    db.phone_vote_question.Add(VoteSet.SelValue(question, ans1, ans2, new Vote()));
                    return correct;
                }

            }

            return incorrect;

        }
        #endregion


        #region MyRegion

        #endregion
    }

}
