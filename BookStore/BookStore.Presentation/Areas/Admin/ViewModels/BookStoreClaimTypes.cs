using System.Collections.Generic;

namespace BookStore.Presentation.Areas.Admin.ViewModels
{
    public static class BookStoreClaimTypes
    {
        public static List<string> ClaimsList { get; set; } =
            new List<string> { "Delete Book", "Add Book", "Age for ordering" };
    }
}
