using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unisystem.Applications.Services;
using Unisystem.Domain.Entities;
using Unisystem.UI.ViewModels;

namespace Unisystem.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserServiceApp _userServiceApp;

        public HomeController()
        {
            _userServiceApp = new UserServiceApp();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_userServiceApp.GetAll());
        }

        [HttpPost]
        public ActionResult Post(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                return Json(_userServiceApp.Insert(Mapper.Map<User>(userVM)), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = new Response();
                response.Status = false;
                response.Message = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault().ErrorMessage;

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return Json(_userServiceApp.Get(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                return Json(_userServiceApp.Update(Mapper.Map<User>(userVM)), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = new Response();
                response.Status = false;
                response.Message = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault().ErrorMessage;

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            return Json(_userServiceApp.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}