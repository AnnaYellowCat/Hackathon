using Khacaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khacaton.Services
{
    public class AwardsService
    {
        private static Model1 db = new Model1();
        public static void changePoints(Accounts account, Awards award, string promocode)
        {
            StudentsAndAwards studentsAndAwards = new StudentsAndAwards(account.id, award.id, promocode, true);
            studentsAndAwards.isActive = true;
            db.StudentsAndAwards.Add(studentsAndAwards);
            db.SaveChanges();
        }
    }
}