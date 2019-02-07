using AutoMapper;
using BookStore.Models;
using BookStore.Presentation.ViewModels;

namespace BookStore
{
    internal class EntityModelMapper : Profile
    {
        public EntityModelMapper()
        {
            #region Enity To Model

            CreateMap<Book, BookViewModel>();
            CreateMap<Book, BookEditViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, CategoryEditViewModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorEditViewModel>();
            CreateMap<Publisher, PublisherViewModel>();
            CreateMap<Publisher, PublisherEditViewModel>();

            #endregion

            #region Model to Entity

            CreateMap<BookViewModel, Book>();
            CreateMap<BookEditViewModel, Book>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<CategoryEditViewModel, Category>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<AuthorEditViewModel, Author>();
            CreateMap<PublisherViewModel, Publisher>();
            CreateMap<PublisherEditViewModel, Publisher>();

            #endregion
        }
    }
}