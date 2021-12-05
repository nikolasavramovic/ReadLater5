using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadLater5.Models;
using ReadLater5.Models.Requests;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadLeter5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        #region privates
        private IBookMarkService _bookMarkService;
        private ICategoryService _categoryService;
        #endregion

        #region ctors
        public BookmarkController(IBookMarkService bookMarkService, ICategoryService categoryService)
        {
            _bookMarkService = bookMarkService;
            _categoryService = categoryService;
        }
        #endregion

        #region readers
        // GET: api/<BookmarkController>
        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.0")]
        [HttpGet]
        public ActionResult<IEnumerable<Bookmark>> Get()
        {
            return Ok(_bookMarkService.GetBookmarks());
        }

        // GET api/<BookmarkController>/5
        [HttpGet("{id}")]
        [Authorize]
        [MapToApiVersion("1.0")]
        public ActionResult<Bookmark> Get(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark bookmark = _bookMarkService.GetBookmark((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return Ok(bookmark);
        }

        #endregion
 
        #region writers
        [HttpPost]
        [Authorize]
        [MapToApiVersion("1.0")]
        public ActionResult Post([FromBody] BookmarkRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookMarkService.CreateBookmark(request.Map());
                    return Ok();
                }
                catch
                {
                    return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
                }
            }
            return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
        }

        // PUT api/<BookmarkController>/5
        [HttpPut]
        [Authorize]
        [MapToApiVersion("1.0")]
        public ActionResult Put(BookmarkRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookMarkService.UpdateBookmark(request.Map());
                    return Ok(); ;
                }
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

            }
            catch
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<BookmarkController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                Bookmark bookmark = _bookMarkService.GetBookmark(id);
                _bookMarkService.DeleteBookmark(bookmark);
                return Ok();
            }
            catch
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
    }
}
