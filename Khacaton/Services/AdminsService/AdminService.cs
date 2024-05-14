using Khacaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khacaton.Services
{
    public static class AdminService
    {
        private static Model1 db=new Model1();
        public static bool CreateStudent(Students student, Students student1)
        {
            student1 = new Students();
            student1.numStud = student.numStud;
            student1.surname = student.surname;
            student1.name = student.name;
            student1.lastname = student.lastname;
            student1.email = student.email;

            Groups groups1 = db.Groups.FirstOrDefault(g => g.direction == student.Groups.direction && g.spec == student.Groups.spec && g.course == student.Groups.course && g.number == student.Groups.number);

            if (groups1 == null)
            {
                return false;
            }
            else
            {
                student1.Groups = groups1;
                db.Students.Add(student1);
                db.SaveChanges();
                return true;
            }
        }
        public static bool UpdateStudent(Students student, Students student1)
        {
            student1.numStud = student.numStud;
            student1.surname = student.surname;
            student1.name = student.name;
            student1.lastname = student.lastname;
            student1.email = student.email;

            Groups groups1 = db.Groups.FirstOrDefault(g => g.direction == student.Groups.direction && g.spec == student.Groups.spec && g.course == student.Groups.course && g.number == student.Groups.number);

            if (groups1 == null)
            {
                return false;
            }
            else
            {
                student1.Groups = groups1;
                student1.Groups.direction = student.Groups.direction;
                student1.Groups.spec = student.Groups.spec;
                student1.Groups.course = student.Groups.course;
                student1.Groups.number = student.Groups.number;
                db.SaveChanges();
                return true;
            }
        }
        public static List<Students> GetStudentsWithAccount()
        {
            List<Students> students=new List<Students>();
            foreach(Accounts accounts in db.Accounts.ToList())
            {
                students.Add(accounts.Students);
            }
            return students;
        }
        public static List<Achievements> GetUnfulfilledAchievements(int studId)
        {
            List<Achievements> achievements=db.Achievements.ToList();
            List<StudentsAndAchievements> studentsAndAchievements = db.StudentsAndAchievements.ToList();
            List<Achievements> achievements1= new List<Achievements>();
            List<Achievements> res=new List<Achievements>();

            foreach(StudentsAndAchievements studentsAndAchievements1 in studentsAndAchievements)
            {
                if(studentsAndAchievements1.Accounts.idStudent.Equals(studId))
                {
                    achievements1.Add(studentsAndAchievements1.Achievements);
                }
            }

            foreach(Achievements ach in achievements)
            {
                if (!achievements1.Contains(ach))
                {
                    res.Add(ach);
                }
            }
            return res;
        }
        public static List<StudentsAndAchievements> RequestAchs()
        {
            List<StudentsAndAchievements> studentsAndAchievements = db.StudentsAndAchievements.Where(x => x.receipt == false).ToList();
            return studentsAndAchievements;
        }
    }
}