using Khacaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Khacaton.Services
{
    public static class AuthService
    {
        private static Model1 db = new Model1();
        public static bool isAuth(Accounts account)
        {
            Accounts temp = db.Accounts.FirstOrDefault(x => x.idStudent == account.idStudent && x.password == account.password);
            return temp != null ? true : false;
        }
        public static bool isExistAccount(int numStud)
        {
            Accounts temp = db.Accounts.FirstOrDefault(x => x.idStudent == numStud);
            return temp != null ? true : false;
        }
        public static bool isExistStud(int numStud)
        {
            Students temp = db.Students.FirstOrDefault(x => x.numStud == numStud);
            return temp != null ? true : false;
        }
        public static Students getStudent(int numStud)
        {
            return db.Students.FirstOrDefault(x => x.numStud == numStud);
        }
        public static void createAccount(Accounts account)
        {
            account.Students = getStudent(account.idStudent);
            account.points = 0;
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public static string createCode(int len)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < len; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }
    }
}