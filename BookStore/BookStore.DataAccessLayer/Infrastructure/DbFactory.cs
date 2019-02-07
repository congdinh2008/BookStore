namespace BookStore.DataAccessLayer
{
    public class DbFactory: Disposable, IDbFactory
    {
        BookStoreDbContext _dbContext;

        public BookStoreDbContext Init() => _dbContext ?? (_dbContext = new BookStoreDbContext());

        protected override void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
