using Entity;
using ReadLater5.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater5.Models
{
    public static class Extensions
    {
        public static Bookmark Map(this BookmarkRequest request)
        {
            return new Bookmark()
            {
                ID = request.ID,
                URL = request.URL,
                ShortDescription = request.ShortDescription,
                CategoryId = request.CategoryId,
                CreateDate = request.CreateDate
            };
        }
        public static Category Map(this CategoryRequest request)
        {
            return new Category()
            {
                ID = request.ID,
                Name = request.Name,
            };
        }

        public static LoginRequest Map(this LoginReq request)
        {
            return new LoginRequest()
            {
                UserName = request.UserName,
                Password = request.Password,
                RememberMe = false
            };
        }
    }
  
    
}
