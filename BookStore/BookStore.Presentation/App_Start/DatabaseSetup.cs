using BookStore.DataAccessLayer;
using System.Data.Entity;

namespace BookStore.Presentation
{
    internal class DatabaseSetup
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DbInitializer());

            using (var db = new BookStoreDbContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}