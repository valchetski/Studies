using System;
using System.Web.Mvc;
using System.Web.Routing;
using DAL;
using DAL.Interfaces;
using Ninject;

namespace KnigoPoisk.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера 
            // используя его тип
            return controllerType == null
              ? null
              : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IBook>().To<BookDB>();
            ninjectKernel.Bind<IAuthor>().To<AuthorDB>();
            ninjectKernel.Bind<INews>().To<NewsDB>();
        }
    }
}