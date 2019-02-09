using BookStore.Common;
using BookStore.Models;
using BookStore.Presentation.Areas.Admin.ViewModels;
using BookStore.Presentation.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace BookStore.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminManagementController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public AdminManagementController()
        {

        }

        public AdminManagementController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        #region UserManager

        public ActionResult UserManagement()
        {
            var users = UserManager.Users;

            return View(users);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addUserViewModel);
            }

            var user = new ApplicationUser()
            {
                Name = addUserViewModel.Name,
                BirthDate = addUserViewModel.BirthDate,
                City = addUserViewModel.City,
                Address = addUserViewModel.Address,
                UserName = addUserViewModel.Email,
                Email = addUserViewModel.Email
            };

            IdentityResult result = await UserManager.CreateAsync(user, addUserViewModel.Password);

            if (result.Succeeded)
                return RedirectToAction("UserManagement", UserManager.Users);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return View(addUserViewModel);
        }

        public async Task<ActionResult> EditUser(int id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
                return RedirectToAction("UserManagement", UserManager.Users);

            var claims = await UserManager.GetClaimsAsync(user.Id);

            var editUserViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                //Sex = user.Sex,
                BirthDate = user.BirthDate,
                City = user.City,
                Address = user.Address,
                Email = user.Email,
                UserClaims = claims.Select(c => c.Value).ToList()
            };

            return View(editUserViewModel);

        }

        [HttpPost]
        public async Task<ActionResult> EditUser(EditUserViewModel editUserViewModel)
        {
            var user = await UserManager.FindByIdAsync(editUserViewModel.Id);

            if (user != null)
            {
                user.Name = editUserViewModel.Name;
                user.Email = editUserViewModel.Email;
                user.BirthDate = editUserViewModel.BirthDate;
                user.City = editUserViewModel.City;
                user.Address = editUserViewModel.Address;

                var result = await UserManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("UserManagement", UserManager.Users);

                ModelState.AddModelError("", "Xảy ra lỗi khi cập nhật tài khoản, vui lòng thử lại.");

                return View(editUserViewModel);
            }

            return RedirectToAction("UserManagement", UserManager.Users);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(int Id)
        {
            var user = await UserManager.FindByIdAsync(Id);

            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Xảy ra lỗi khi xóa tài khoản, vui lòng thử lại.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại!");
            }
            return View("UserManagement", UserManager.Users);
        }
        #endregion

        #region RoleManager

        public ActionResult RoleManagement()
        {
            var roles = RoleManager.Roles;
            return View(roles);
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(
            AddRoleViewModel addRoleViewModel)
        {
            if (!ModelState.IsValid)
                return View(addRoleViewModel);

            var role = new ApplicationRole
            {
                Name = addRoleViewModel.Name
            };

            IdentityResult result = await RoleManager.CreateAsync(role);

            if (result.Succeeded)
                return RedirectToAction("RoleManagement", RoleManager.Roles);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View(addRoleViewModel);
        }

        public async Task<ActionResult> EditRole(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);

            if (role == null)
                return RedirectToAction("RoleManagement", RoleManager.Roles);

            var editRoleViewModel = new EditRoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                Users = new List<string>()
            };

            foreach (var user in UserManager.Users)
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                    editRoleViewModel.Users.Add(user.UserName);
            }

            return View(editRoleViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditRole(EditRoleViewModel editRoleViewModel)
        {
            var role = await RoleManager.FindByIdAsync(editRoleViewModel.Id);

            if (role != null)
            {
                role.Name = editRoleViewModel.Name;

                var result = await RoleManager.UpdateAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("RoleManagement", RoleManager.Roles);

                ModelState.AddModelError("", "Role not updated, something went wrong.");

                return View(editRoleViewModel);
            }

            return RedirectToAction("RoleManagement", RoleManager.Roles);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRole(int id)
        {
            ApplicationRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleManagement", RoleManager.Roles);
                }

                ModelState.AddModelError("", "Something went wrong while deleting this role.");
            }
            else
            {
                ModelState.AddModelError("", "This role can't be found.");
            }
            return View("RoleManagement", RoleManager.Roles);
        }

        //Users in roles

        public async Task<ActionResult> AddUserToRole(int roleId)
        {
            var role = await RoleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return RedirectToAction("RoleManagement", RoleManager.Roles);
            }

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in UserManager.Users)
            {
                if (!await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await UserManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await RoleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await UserManager.AddToRoleAsync(user.Id, role.Name);

            if (result.Succeeded)
                return RedirectToAction("RoleManagement", RoleManager.Roles);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View(userRoleViewModel);
        }

        public async Task<ActionResult> DeleteUserFromRole(int roleId)
        {
            var role = await RoleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", RoleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in UserManager.Users)
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                    addUserToRoleViewModel.Users.Add(user);
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUserFromRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await UserManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await RoleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await UserManager.RemoveFromRoleAsync(user.Id, role.Name);

            if (result.Succeeded)
                return RedirectToAction("RoleManagement", RoleManager.Roles);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View(userRoleViewModel);
        }

        #endregion

        #region Claims

        public async Task<ActionResult> ManageClaimsForUser(int userId)
        {
            var user = await UserManager.FindByIdAsync(userId);

            if (user == null)
                return RedirectToAction("UserManagement", UserManager.Users);

            var claimsManagementViewModel =
                new ClaimsManagementViewModel
                {
                    UserId = user.Id,
                    AllClaimsList = BookStoreClaimTypes.ClaimsList
                };

            return View(claimsManagementViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> ManageClaimsForUser(ClaimsManagementViewModel claimsManagementViewModel)
        {
            var user = await UserManager.FindByIdAsync(claimsManagementViewModel.UserId);

            if (user == null)
                return RedirectToAction("UserManagement", UserManager.Users);

            CustomUserClaim claim =
                new CustomUserClaim
                {
                    UserId = user.Id,
                    ClaimType = claimsManagementViewModel.ClaimId.ToString(),
                    ClaimValue = claimsManagementViewModel.ClaimId.ToString()
                };

            user.Claims.Add(claim);
            var result = await UserManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("EditUser", new { id = claimsManagementViewModel.UserId });

            ModelState.AddModelError("", "User Update error.");

            return View(claimsManagementViewModel);
        }

        #endregion

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var cart = Session[ConstantCommon.Cart];
            var cartItem = (List<ShoppingCartItem>)cart;
            if (cartItem == null)
            {
                return RedirectToAction("Login", "Account", new { Area = "" });
            }
            cartItem.Clear();
            return RedirectToAction("Login", "Account", new { Area = "" });
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}