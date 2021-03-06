using Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //in real world applications best practice is to use repository pattern with unit of work pattern to ensure transactions consistency
    public class BookMarkService : IBookMarkService
    {
        private ReadLaterDataContext _ReadLaterDataContext;

        public BookMarkService(ReadLaterDataContext readLaterDataContext)
        {
            _ReadLaterDataContext = readLaterDataContext;
        }

        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Add(bookmark);
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public List<Bookmark> GetBookmarks()
        {
            return _ReadLaterDataContext.Bookmark.Include(x =>x.Category).ToList();
        }

        public Bookmark GetBookmark(int Id)
        {
            return _ReadLaterDataContext.Bookmark.Include(x => x.Category).Where(c => c.ID == Id).FirstOrDefault();
        }

        //Bookmark entity has no name

        //public Bookmark GetBookmark(string Name)
        //{
        //    return _ReadLaterDataContext.Bookmark.Where(c => c.Name == Name).FirstOrDefault();
        //}

        public void DeleteBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Bookmark.Remove(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        

    }
}
