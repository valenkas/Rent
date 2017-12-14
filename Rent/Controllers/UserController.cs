
using Rent.Context;
using Rent.Models;
using Rent.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Rent.Controllers
{
    public class UserController : Controller
    {
        Aparts apart = new Aparts();

        private UsersRepository usersrepository;
        private ApartsRepository apartrepository;
        DbContext db = new DbContext();
        string search;

        public UserController()
        {
            usersrepository = new UsersRepository();
            apartrepository = new ApartsRepository();
        }

        public ActionResult Main(Aparts apart)
        {
            if (Session["UserID"] == Session["ApartUserID"])
            {
                return View(apartrepository.GetAparts());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ViewResult SearchInAparts(string Type)
        {
            return View(Type == null ? db.Aparts : db.Aparts.Where(x => x.ApartType.Contains(Type)));
        }

        //public ActionResult SearchInAparts()
        //{
        //    string find = search;
        //    IQueryable<Aparts> apart = db.Aparts;
        //    //string find = this.Request.QueryString["Type"];
        //    if (find !=null)
        //    {
        //        Aparts aprt = new Aparts();
        //        ViewBag.aprt = apart.Where(x => x.ApartType.Contains(find)).ToList();
        //    }
        //    else
        //    {
        //        ViewBag.aprt = apart;
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult Find(string Type, Aparts apart)
        {
            search = Type;
            return RedirectToAction("SearchInAparts");
        }

        public ActionResult GetUsers()
        {
            return View(usersrepository.GetUsers());
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Users usermodel)
        {
            using (DbContext db = new DbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(usermodel);
                    db.SaveChanges();
                    ViewBag.Message = "пользователь" + " " + usermodel.UserName + " " + usermodel.UserSurname + " " + "успешно зарегистрирован";
                    return View();
                }
                else
                {
                    return View();
                }
                
            }
        }


        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(Users user)
        {
            using (DbContext db = new DbContext())
            {
                var usr = db.Users.Where(u => u.UserLogin == user.UserLogin && u.UserPassword == user.UserPassword).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.ID;
                    Session["UserName"] = usr.UserName;
                    Session["UserSurname"] = usr.UserSurname;
                    Session["ApartUserID"] = Session["UserID"];
                    apart.UserId = usr.ID;
                    return RedirectToAction("Main", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Неверно введены данные.");
                }
            }
            return View();
        }


        public ActionResult AddApartByUser()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddApartByUser(int id = 0)
        {
            Aparts apart = new Aparts();
            return View(apart);
        }

        [HttpPost]
        public ActionResult AddApartByUser(Aparts apartmodel, HttpPostedFileBase Image)
        {
            using (DbContext db = new DbContext())
            {
                if (ModelState.IsValid)
                {
                    if (Image != null)
                    {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(Image.InputStream))
                        {
                            imageData = binaryReader.ReadBytes(Image.ContentLength);
                        }
                        apartmodel.ApartImage = imageData;
                    }
                    db.Aparts.Add(apartmodel);
                    db.SaveChanges();
                    ViewBag.Message = "объявение" + " " + apartmodel.ApartType + " " + "успешно добавлено"; 
                    
                    return RedirectToAction("Main");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}