using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class NewsDB : INews
    {
        private KnigoPoiskContext context = new KnigoPoiskContext();

        public IQueryable<News> Newses
        {
            get { return context.News; }
        }

        public News Find(int? id)
        {
            return context.News.Find(id);
        }

        public void Save(News news)
        {
            context.News.AddOrUpdate(news);
            context.SaveChanges();
        }
        public void Delete(News news)
        {
            context.News.Remove(context.News.Find(news.Id));
            context.SaveChanges();
        }
    }
}
