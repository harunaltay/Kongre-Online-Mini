using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kongre_Online_Mini.MVC.Models;
using System.Web.Security;

namespace Kongre_Online_Mini.MVC.Controllers
{
    public class AccountController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Account
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //    /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        //    /Account/Register
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;

                //Membership.CreateUser(model.Username, model.Password, model.Email, "question", "answer", true, out createStatus);
                Membership.CreateUser(model.Username, model.Password, model.Email, "question", "answer", true, out createStatus);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    Roles.AddUserToRole(model.Username, "Uye");
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("CreateUserDetails", "Account");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult CreateUserDetails
            (Uye uye)
        {
            //userDetailsConcrete.Add(uye);
            //InsertToDB_and_SaveChanges(uye);

            if (ModelState.IsValid)
            {
                var user = Membership.GetUser(User.Identity.Name);
                Guid newGuid2 = (Guid)user.ProviderUserKey;


                string userId = Membership.GetUser().ProviderUserKey.ToString();
                Guid newGuid1 = Guid.Parse(userId);
                Guid newGuid3 = (Guid) Membership.GetUser().ProviderUserKey;

                //uye.UyeId = newGuid1;
                //uye.UyeId = newGuid2;
                uye.UyeId = newGuid3;
                //uye.UyeId = Guid.NewGuid();
                db.Uye.Add(uye);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(uye);
        }


        //  /Account/CreateUserDetails
        [Authorize]
        public ActionResult CreateUserDetails()
        {
            // first, use Membership, to find the current user!

            var user = Membership.GetUser(User.Identity.Name);
            Guid newGuid2 = (Guid)user.ProviderUserKey;

            string userId = Membership.GetUser().ProviderUserKey.ToString();
            Guid newGuid = Guid.Parse(userId);

            ViewBag.userId = userId;
            ViewBag.newGuid = newGuid;
            ViewBag.newGuid2 = newGuid2;

            // bu aşağıdaki olmadı! Guid'i -> string'e dönüştüremem dedi!
            // ViewData[newGuid] = newGuid;

            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi");
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi");
            ViewBag.UlkeId = new SelectList(db.Ulke, "UlkeId", "UlkeAdi");

            return View();
        }


        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }


        // /Account/ChangePassword
        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            string s = "";

            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    s += User.Identity.Name.ToString() + "\n";
                    MembershipUser currentUser = Membership.GetUser(User.Identity, true);
                    s += "User.Identity: " + User.Identity + "\n";
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                    s += "model.OldPassword: " + model.OldPassword + "\n model.NewPassword: " + model.NewPassword + "\n";
                }
                catch (Exception exception)
                {
                    changePasswordSucceeded = false;
                    s += exception.ToString() + "\n";
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", s + "\nThe current password is incorrect or the new password is invalid.");
                }
            }
            return View(model);
        }


        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        // ChangePassword ü çalıştırınca, aşağıdaki hatayı veriyor!
        // çalışmıyor!
/*        Password change was unsuccessful.Please correct the errors and try again.
            uye2 System.ArgumentException: Girilen sağlayıcı kullanıcı anahtarı geçersiz.System.Guid türünde olmalıdır.
            Parametre adı: providerUserKey 
            konum: System.Web.Security.SqlMembershipProvider.GetUser(Object providerUserKey, Boolean userIsOnline) 
            konum: System.Web.Security.Membership.GetUser(Object providerUserKey, Boolean userIsOnline) 
            konum: Kongre_Online_Mini.MVC.Controllers.AccountController.ChangePassword(ChangePasswordModel model) 
            D:\GitHub.com-Kongre-Online-Mini\Kongre_Online_Mini_Solution\Kongre_Online_Mini.MVC\Controllers\AccountController.cs 
            içinde: satır 107 
        The current password is incorrect or the new password is invalid.
*/

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion


    }





}