using BookStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.DataAccessLayer
{
    public class CustomRoleStore : RoleStore<ApplicationRole, int, CustomUserRole>
    {
        public CustomRoleStore(BookStoreDbContext context) : base(context)
        {
        }
    }
}
