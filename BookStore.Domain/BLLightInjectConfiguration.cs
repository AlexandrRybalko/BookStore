using BookStore.DAL;
using BookStore.DAL.Repositories;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class BLLightInjectConfiguration
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {
            container.Register<BookStoreContext>(new PerScopeLifetime());
            container.Register<IAuthorRepository, AuthorRepository>();
            container.Register<IGenreRepository, GenreRepository>();
            container.Register<IBookRepository, BookRepository>();
            container.Register<IOrderRepository, OrderRepository>();

            return container;
        }
    }
}
