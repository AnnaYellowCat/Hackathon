using Khacaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khacaton.Services
{
    public static class AccountService
    {
        private static Model1 db = new Model1();
        private static List<Accounts> lst = db.Accounts.ToList();
        public static Accounts fillingAccount(Accounts account)
        {
            Accounts temp = db.Accounts.FirstOrDefault(x => x.idStudent == account.idStudent);
            temp.myPosition = myPosition(temp);
            temp.balance = getBalance(temp);
            return temp;
        }
        public static List<Accounts> getLstSort()
        {
            List<Accounts> lst1 = db.Accounts.ToList();
            foreach (var l in lst1)
            {
                l.myPosition = myPosition(l);
            }
            lst1.Sort();
            return lst;
        }
        public static int myPosition(Accounts account)
        {
            lst.Sort();
            return lst.IndexOf(account) + 1;
        }
        public static int getBalance(Accounts account)
        {
            List<StudentsAndAchievements> lstAc = db.StudentsAndAchievements.Where(x => x.idAccount == account.id).ToList();
            int sumAch = (int)lstAc.Sum(x => x.Achievements.reward);
            List<StudentsAndAwards> lstAw = db.StudentsAndAwards.Where(x => x.idAccount == account.id).ToList();
            int sumAw = (int)lstAw.Sum(x => x.Awards.cost);
            return sumAch - sumAw;
        }
    }
}