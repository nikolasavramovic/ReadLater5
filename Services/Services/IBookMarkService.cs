using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookMarkService
    {
        Bookmark CreateBookmark(Bookmark bookmark);
        void UpdateBookmark(Bookmark bookmark);
        List<Bookmark> GetBookmarks();
        Bookmark GetBookmark(int Id);
        void DeleteBookmark(Bookmark bookmark);
    }
}
