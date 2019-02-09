using System;
using System.Collections.Generic;

namespace BookStore.Presentation.ViewModels
{
    public class ClaimsManagementViewModel
    {
        public int UserId { get; set; }
        public int ClaimId { get; set; }
        public List<string> AllClaimsList { get; set; }
    }
}
