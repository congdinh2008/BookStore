using BookStore.DataAccessLayer;
using BookStore.Models;
using System.Security.Principal;

namespace BookStore.Presentation
{
    public static class UserExtension
    {
        public static ApplicationUser GetApplicationUser(this IIdentity identity)
        {
            if (identity.IsAuthenticated)
            {
                using (var db = new BookStoreDbContext())
                {
                    var userManager = new ApplicationUserManager(new CustomUserStore(db));
                    return userManager.FindByNameAsync(identity.Name).Result;
                }
            }
            else
            {
                return null;
            }
        }

        public static bool IsRole(this IIdentity identity, string roleName)
        {
            if (identity.IsAuthenticated)
            {
                using (var db = new BookStoreDbContext())
                {
                    var userManager = new ApplicationUserManager(new CustomUserStore(db));
                    return userManager.IsInRoleAsync(identity.GetApplicationUser().Id, roleName).Result;
                }
            }
            else
            {
                return false;
            }
        }
    }
}