using BookStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.DataAccessLayer
{
    public class CustomUserStore : UserStore<ApplicationUser, ApplicationRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(BookStoreDbContext context) : base(context)
        {
        }
    }
}
