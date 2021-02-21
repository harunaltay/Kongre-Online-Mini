using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kongre_Online_Mini.MVC.Controllers
{
    [Authorize]
    public class EkleRolesUsersController : Controller
    {
        // /EkleRolesUsers/CreateRoles
        public ActionResult CreateRoles()
        {
            //Roles.CreateRole("Uye");
            //Roles.CreateRole("Sekreterya");
            //Roles.CreateRole("Admin");

            return View();
        }


        // önce bunları elle yap!
        // harun : uye
        // malik : sekreterya
        // yasin : admin

        // ali : uye -> sonra programla, controller ve view ile denenecek, denenecek!

        // /EkleRolesUsers/CreateUsers
        public ActionResult CreateUsers()
        {
            //Membership.CreateUser("harun", "123", "harun@kongre.com");
            //Membership.CreateUser("malik", "123", "malik@kongre.com");
            //Membership.CreateUser("yasin", "123", "yasin@kongre.com");

            return View();
        }


        // /EkleRolesUsers/AssignUsersToRoles
        public ActionResult AssignUsersToRoles()
        {
            //Roles.AddUserToRole("harun", "Uye"); // bende bu çalışmadı! ilkinde
            //Roles.AddUserToRole("malik", "Sekreterya"); // bende bu çalışmadı! ilkinde
            //Roles.AddUserToRole("yasin", "Admin"); // bende bu çalışmadı! ilkinde

            return View();
        }


        // /EkleRolesUsers/DeleteUsers
        public ActionResult DeleteUsers()
        {
            //Membership.DeleteUser("uye", true);
            //Membership.DeleteUser("uye2", true);
            //Membership.DeleteUser("sekreterya", true);
            //Membership.DeleteUser("admin", true);

            // true şunun için gerekli: ilgili başka verileri de siliyormuş. Ne ise artık! Herhalde gereklidir!

            return View();
        }
    }
}