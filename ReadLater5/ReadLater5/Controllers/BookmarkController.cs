using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    [Authorize]
    public class BookmarkController : Controller
    {
        IBookMarkService _bookMarkService;
        ICategoryService _categoryService;
        public BookmarkController(IBookMarkService bookMarkService, ICategoryService categoryService)
        {
            _bookMarkService = bookMarkService;
            _categoryService = categoryService;
        }
        // GET: BookmarkController1
        public ActionResult Index()
        {
            List<Bookmark> model = _bookMarkService.GetBookmarks();
            return View(model);
        }

        // GET: BookmarkController1/Details/5
        public ActionResult Details(int? id)
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
            return View(bookmark);
        }

        // GET: BookmarkController1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetCategories(), "ID", "Name");

            return View();
        }

        // POST: BookmarkController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookMarkService.CreateBookmark(bookmark);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(bookmark);

        }

        // GET: BookmarkController1/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryId = new SelectList(_categoryService.GetCategories(), "ID", "Name");
            return View(bookmark);
        }

        // POST: BookmarkController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bookmark bookmark)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    _bookMarkService.UpdateBookmark(bookmark);
                    return RedirectToAction("Index");
                }
                return View(bookmark);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: BookmarkController1/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
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
            return View(bookmark);
        }

        // POST: BookmarkController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Bookmark bookmark = _bookMarkService.GetBookmark(id);
                _bookMarkService.DeleteBookmark(bookmark);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
