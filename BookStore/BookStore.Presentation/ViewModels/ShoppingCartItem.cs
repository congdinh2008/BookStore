using BookStore.Models;
using System;

namespace BookStore.Presentation.ViewModels
{
    [Serializable]
    public class ShoppingCartItem
    {
        public int BookId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get { return Quantity * Price; } }

        public virtual Book Book { get; set; }
    }
}
