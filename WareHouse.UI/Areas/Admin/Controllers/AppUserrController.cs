using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.Model.Enum;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class AppUserrController : BaseController
    {
       
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserDTO model)

        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Role = model.Role;
                user.Gender = model.Gender;
                db.AppUsers.Add(user);
                db.SaveChanges();
                return View();


            }
            else
            {
                return View();

            }


        }
        public ActionResult AppUserList()
        {
            List<UserDTO> model = db.AppUsers.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).Select(x => new UserDTO
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName=x.UserName,
                Email=x.Email,
                Password=x.Password,
                Gender=x.Gender,
                Role=x.Role
            }).ToList();

            return View(model);
        }

        public ActionResult UpdateAppUser(int id)
        {
           AppUser appuser = db.AppUsers.FirstOrDefault(x => x.ID == id);
           UserDTO model = new UserDTO();
            model.ID = appuser.ID;
            model.FirstName = appuser.FirstName;
            model.LastName = appuser.LastName;
            model.UserName = appuser.UserName;
            model.Email = appuser.Email;
            model.Password = appuser.Password;
            model.Gender = appuser.Gender;
            model.Role = appuser.Role;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateAppUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser= db.AppUsers.FirstOrDefault(x => x.ID == model.ID);
                appuser.FirstName = model.FirstName;
                appuser.LastName = model.LastName;
                appuser.UserName = model.UserName;
                appuser.Email = model.Email;
                appuser.Password = model.Password;
                appuser.Gender = model.Gender;
                appuser.Role = model.Role;
                appuser.Status = WareHouse.Model.Enum.Status.Updated;
                appuser.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUserr/AppUserList");
            }
            else
            {
                return Redirect("/Admin/AppUserr/AppUserList");
            }

        }

        public ActionResult DeleteAppUser(int id)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser= db.AppUsers.FirstOrDefault(x => x.ID == id);
                appuser.Status = WareHouse.Model.Enum.Status.Deleted;
                appuser.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUserr/AppUserList");
            }
            return Redirect("/Admin/AppUserr/AppUserList");
        }
    }
}
    

