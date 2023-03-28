using MVCAssignment.Models;
using MVCAssignment.Repository;
using SH_MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAssignment.Controllers
{

    public class CategoryController : Controller
    {
        public readonly IGenericRepositary<Category> _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new GenericRepository<Category>();
        }
        public ActionResult Index()
        {
            var data = _categoryRepository.GetAll();
            return View(data);
        }
        [HttpPost]
        public ActionResult Insert(InsertRequest model)
        {
            Category category = new Category()
            {
                CategoryName = model.CategoryName,
                CreatedOn = DateTime.Now
            };
            _categoryRepository.Insert(category);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }
    

        [HttpPost]
        public ActionResult Delete(int id)
        {   
            var categoryRow = _categoryRepository.GetById(id);
            if (categoryRow != null)
            {
                _categoryRepository.Delete(id);
                _categoryRepository.Save();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int CategoryId)
        {
            Category catagory = _categoryRepository.GetById(CategoryId);
            return View(catagory);
        }
        [HttpPost] 
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                _categoryRepository.Update(model);
                _categoryRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}