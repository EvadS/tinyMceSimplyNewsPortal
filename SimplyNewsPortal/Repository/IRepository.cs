using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyNewsPortal.Repository
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetBlogList(); // получение всех объектов
       
        /// <summary>
        /// take pageTake size   data from a pageSkip  as a startposition 
        /// </summary>
        /// <param name="pageSkip">start position</param>
        /// <param name="pageTake">page size</param>
        /// <returns></returns>
        IEnumerable<T> GetBlogList(int pageSkip, int pageTake);
        T GetBlog(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений

        int GetDataCount();
    }
}
