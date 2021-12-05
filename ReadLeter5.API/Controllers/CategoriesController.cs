using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class CategoriesController : ControllerBase
    {
        #region privates
        private ICategoryService _categoryService;
        #endregion

        #region ctors
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        #region readers
        // GET: api/<CategoriesController>
        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.0")]
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            List<Category> model = _categoryService.GetCategories();
            return Ok(model);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        [Authorize]
        [MapToApiVersion("1.0")]
        public ActionResult<Category> Get(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Category category = _categoryService.GetCategory((int)id);
            if (category == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return Ok(category);
        }
        #endregion

        #region writers
        // POST api/<CategoriesController>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.CreateCategory(category);
                    return Ok();
                }
                catch
                {
                    return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
                }
            }
            return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

        }

        [HttpPut]
        [Authorize]
        [MapToApiVersion("1.0")]
        public ActionResult Put(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.UpdateCategory(category);
                    return Ok(); ;
                }
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

            }
            catch
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                Category category = _categoryService.GetCategory(id);
                _categoryService.DeleteCategory(category);
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
