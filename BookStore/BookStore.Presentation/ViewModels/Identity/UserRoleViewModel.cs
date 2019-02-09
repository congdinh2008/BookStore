using BookStore.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Presentation.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<ApplicationUser>();
        }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
