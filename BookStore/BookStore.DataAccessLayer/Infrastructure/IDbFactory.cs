using System;

namespace BookStore.DataAccessLayer
{
    public interface IDbFactory: IDisposable
    {
        BookStoreDbContext Init();
    }
}
