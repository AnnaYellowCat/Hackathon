using Khacaton.Models;
using Khacaton.Services;
using Khacaton.Services.AdminsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Khacaton.Controllers
{
    public class BaseController : Controller
    {
        Model1 db = new Model1();
        IAuthProvider authProvider = new FormAuthProvider();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAchievement()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Fail()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View((Accounts)Session["account"]);
        }
        [HttpGet]
        public ActionResult Awards()
        {
            Awards award = new Awards();
            award.lstAwards = db.Awards.ToList();
            Accounts account = (Accounts)Session["account"];
            account.balance = AccountService.getBalance(account);
            ViewBag.bal = account.balance;
            return View("Awards", award);
        }
        [HttpGet]
        public ActionResult Achievements()
        {
            Achievements achievements = new Achievements();
            Accounts account = (Accounts)Session["account"];
            achievements.lstMy = AchievementService.getMyAchievements(account);
            achievements.lstDiff = AchievementService.getDiffAchievements(account);
            return View(achievements);
        }




        [HttpGet]
        [Authorize]
        public ActionResult AdminPage()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AdminEdit(int studId)
        {
            Students student = db.Students
                .FirstOrDefault(g => g.numStud == studId);
            return View(student);
        }
        [HttpGet]
        public ActionResult AdminAccounts()
        {
            Session["listAch"] = db.Achievements.ToList();
            return View(db.Accounts);
        }
       
        [HttpGet]
        public ActionResult AdminStudents()
        {
            return View(db.Students);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View("AdminEdit", new Students());
        }







        [HttpPost]
        public ActionResult Login(Accounts account)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(account.idStudent.ToString(), account.password))
                {
                    return Redirect(Url.Action("AdminPage", "Base"));
                }
                else
                {
                    if (AuthService.isAuth(account))
                    {
                        account = AccountService.fillingAccount(account);
                        Session["account"] = account;
                        return View("Profile", account);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Такого аккаунта не сущетсвует или неверный логин или пароль";
                        return View();
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Confirmation(ConfirmEmail confirnEmail)
        {
            confirnEmail.code = Session["code"].ToString();
            if (confirnEmail.code == confirnEmail.codeInSite)
            {
                AuthService.createAccount((Accounts)Session["account"]);
                return RedirectToAction("Login", "Base");
            }
            else
            {
                ViewBag.ErrorMessage = "Пароль не совпадает, повторите попытку";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Registration(Accounts account)
        {
            if (ModelState.IsValid)
            {
                if (AuthService.isExistStud(account.idStudent))
                {
                    if (!AuthService.isExistAccount(account.idStudent))
                    {
                        string subj = "Регистрация на сервисе личного кабинета СГТУ";
                        string code = AuthService.createCode(5);
                        ConfirmEmail confirnEmail = new ConfirmEmail();
                        confirnEmail.code = code;
                        string bod = "Для подтверждения регистрации введите код:" + code + " на сайте приложения";

                        try
                        {
                            MailService.sendMessage(account, subj, bod);
                            Session["account"] = account;
                            Session["code"] = code;
                            return RedirectToAction("Confirmation", "Base");
                        }
                        catch
                        {
                            ViewBag.ErrorMessage = "Что-то пошло не так";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Аккаунт у этого студента уже существует";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Студента с таким номером зачетки не существует";
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Awards(Awards award)
        {
            Accounts account = (Accounts)Session["account"];
            if (account.balance > award.cost) 
            {
                string subj = "Промокод от сервиса личного кабинета СГТУ";
                string code = AuthService.createCode(6);
                string body = "Ваш промокод: " + code + " для получения награды\nНазвание: " + award.title + "\nОписание: " + award.description;

                try
                {
                    //MailService.sendMessage(account, subj, body);
                    AwardsService.changePoints(account, award, code);
                }
                catch
                {
                    ViewBag.ErrorMessage = "Что-то пошло не так";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "У вас недостаточно очков";
            }
            award.lstAwards = db.Awards.ToList();
            Accounts accoun = (Accounts)Session["account"];
            accoun.balance = AccountService.getBalance(accoun);
            ViewBag.bal = accoun.balance;
            return View(award);
        }
       

        [HttpPost]
        public ActionResult AdminEdit(Students student)
        {
            if (ModelState.IsValid)
            {
                Students student1 = db.Students.FirstOrDefault(g => g.numStud == student.numStud);
                if (student1 == null)
                {
                    bool b = AdminService.CreateStudent(student, student1);

                    if (!b)
                    {
                        ViewBag.ErrorMessage = "Такой группы не существует";
                        return View();
                    }
                }
                else
                {
                    bool b = AdminService.UpdateStudent(student, student1);

                    if (!b)
                    {
                        ViewBag.ErrorMessage = "Такой группы не существует";
                        return View();
                    }

                }
                return RedirectToAction("AdminStudents", "Base");
            }
            else
            {
                return View(student);
            }
        }
        [HttpPost]
        public ActionResult Delete(int studId)
        {
            Students deletedStud = db.Students.Remove(db.Students.FirstOrDefault(g => g.numStud == studId));
            db.SaveChanges();
            return RedirectToAction("AdminStudents", "Base");
        }
        [HttpPost]
        public ActionResult AchievementsNastya(int studId)
        {
            ViewBag.student = db.Students.FirstOrDefault(g => g.numStud == studId);
            List<Achievements> lst = (List<Achievements>)Session["listAch"];
            Session["listAch"] = lst;
            return View(lst);
        }
        [HttpGet]
        public ActionResult AdminAchievements(int studId, int achId)
        {
            Achievements achievement = db.Achievements.FirstOrDefault(g => g.id == achId);
            Students student = db.Students.FirstOrDefault(g => g.numStud == studId);
            Accounts accounts = db.Accounts.FirstOrDefault(g => g.idStudent == studId);

            StudentsAndAchievements studentsAndAchievements = new StudentsAndAchievements();
            studentsAndAchievements.idAchievement = achId;
            int t = accounts.idStudent;
            studentsAndAchievements.idAccount = t;
            DateTime d = DateTime.Now;
            studentsAndAchievements.dateReceipt = d;
            //studentsAndAchievements.dateReceipt = d.ToString("yyyy-MM-dd HH:mm:ss.fff");
            studentsAndAchievements.Accounts = accounts;
            studentsAndAchievements.Achievements = achievement;

            accounts.points += achievement.reward;

            db.StudentsAndAchievements.Add(studentsAndAchievements);
            List<Achievements> listt = (List<Achievements>)Session["listAch"];
            listt.Remove(listt.FirstOrDefault(x => x.id == achievement.id));
            db.SaveChanges();
            ViewBag.student = db.Students.FirstOrDefault(g => g.numStud == studId);
            Session["listAch"] = listt;
            return View("AchievementsNastya", listt);
        }
        [HttpPost]
        public ActionResult AddAchievement(Achievements achievement)
        {
            achievement.reward = 10;
            achievement.image = "/Images/notReceived.png";
            db.Achievements.Add(achievement);
            db.SaveChanges();

            StudentsAndAchievements studentsAndAchievements = new StudentsAndAchievements();
            Accounts accoun = (Accounts)Session["account"];
            studentsAndAchievements.idAccount = accoun.id;
            studentsAndAchievements.idAchievement = achievement.id;
            studentsAndAchievements.receipt = false;

            db.StudentsAndAchievements.Add(studentsAndAchievements);
            db.SaveChanges();

            return View("GramotLoad");
        }
        [HttpGet]
        public ActionResult RequestAch()
        {
            return View(AdminService.RequestAchs());
        }
        [HttpPost]
        public ActionResult RequestAch(int achId)
        {
            StudentsAndAchievements studentsAndAchievements = db.StudentsAndAchievements.FirstOrDefault(g => g.id == achId);
            studentsAndAchievements.dateReceipt = DateTime.Now;
            studentsAndAchievements.receipt = true;
            db.SaveChanges();
            return RedirectToAction("RequestAch", "Base", AdminService.RequestAchs());
        }
        public ActionResult Rank()
        {
            Accounts account = new Accounts();
            account.lst = AccountService.getLstSort();
            return View(account);
        }
    }
}