using BookStore.BusinessLogicLayer;
using BookStore.DataAccessLayer;
using BookStore.Models;
using BookStore.Presentation.Areas.Admin.Controllers;
using BookStore.Presentation.Controllers;
using System;

using Unity;
using Unity.Injection;

namespace BookStore.Presentation
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<AdminManagementController>(new InjectionConstructor());

            container.RegisterSingleton<BookStoreDbContext, BookStoreDbContext>();
            container.RegisterSingleton<IDbFactory, DbFactory>();
            container.RegisterSingleton<IUnitOfWork, UnitOfWork>();

            container.RegisterType<ICheckoutService, CheckoutService>();

            container.RegisterType<IGenericRepository<Book>, GenericRepository<Book>>();
            container.RegisterType<IBookService, BookService>();

            container.RegisterType<IGenericRepository<Review>, GenericRepository<Review>>();
            container.RegisterType<IReviewService, ReviewService>();

            container.RegisterType<IGenericRepository<Category>, GenericRepository<Category>>();
            container.RegisterType<ICategoryService, CategoryService>();

            container.RegisterType<IGenericRepository<Author>, GenericRepository<Author>>();
            container.RegisterType<IAuthorService, AuthorService>();

            container.RegisterType<IGenericRepository<Publisher>, GenericRepository<Publisher>>();
            container.RegisterType<IPublisherService, PublisherService>();

            container.RegisterType<IGenericRepository<Order>, GenericRepository<Order>>();
            container.RegisterType<IOrderService, OrderService>();

            container.RegisterType<IGenericRepository<OrderDetail>, GenericRepository<OrderDetail>>();
            container.RegisterType<IOrderDetailService, OrderDetailService>();
        }
    }
}