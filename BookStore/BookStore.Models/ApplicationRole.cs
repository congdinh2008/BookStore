using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Models
{
    public class ApplicationRole : IdentityRole<int, CustomUserRole>
    {
    }
}
