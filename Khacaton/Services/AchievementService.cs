using Khacaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khacaton.Services
{
    public static class AchievementService
    {
        private static Model1 db = new Model1();
        public static List<Achievements> getMyAchievements(Accounts account)
        {
            List<StudentsAndAchievements> temp = db.StudentsAndAchievements.ToList();
            List<Achievements> res = new List<Achievements>();
            foreach(var t in temp)
            {
                if (t.receipt==true)
                {
                    res.Add(t.Achievements);
                }
                
            }
            return res;
        }
        public static List<Achievements> getDiffAchievements(Accounts account)
        {
            List<Achievements> all = db.Achievements.ToList();
            List<Achievements> my = getMyAchievements(account);
            List<Achievements> res = new List<Achievements>();
            foreach(var a in all)
            {
                foreach(var m in my)
                {
                    if (a.id == m.id)
                    {
                        break;
                    }
                }
                res.Add(a);
            }
            return res;
        }
    }
}