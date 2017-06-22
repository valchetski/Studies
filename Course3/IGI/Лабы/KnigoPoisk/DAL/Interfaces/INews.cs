using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface INews
    {
        IQueryable<News> Newses { get; }
        void Save(News news);
        void Delete(News news);
        News Find(int? id);
    }
}
