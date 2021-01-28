using BookStore.Domain;
using BookStore.Domain.Services;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BookStore.App_Start
{
    public class LightInjectConfiguration
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            //var config = new MapperConfiguration(cfg => cfg.AddProfiles(
            //      new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            /*            container.Register(c => config.CreateMapper())*/


            container = BLLightInjectConfiguration.Configuration(container);

            container.Register<IBookService, BookService>();
            //container.Register<IAuthorService, AuthorService>();
            //container.Register<IEmailService, EmailService>();
            //container.Register<IArticleApiService, ArticleApiService>();
            //var resolver = new LightInjectWebApiDependencyResolver(container);             
            //DependencyResolver.SetResolver(new LightInjectMvcDependencyResolver(container));
            container.EnableMvc();
        }
    }
}