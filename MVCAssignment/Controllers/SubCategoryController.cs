using MVCAssignment.Models;
using MVCAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAssignment.Controllers
{
   
    public class SubCategoryController : Controller
    {
        public readonly IGenericRepositary<SubCategory> _SubCategoryRepository;
        public readonly IGenericRepositary<Category> _CategoryRepository;

        public SubCategoryController()
        {
            _SubCategoryRepository = new GenericRepository<SubCategory>();
            _CategoryRepository = new GenericRepository<Category>();
        }
        // GET: SubCategory
        public ActionResult Index()
        {
            var data = _SubCategoryRepository.GetAll();
            ViewBag.categorylist = _CategoryRepository.GetAll().ToList();
            return View(data);

        }
        [HttpPost]
        public ActionResult Insert(SubCategory model)
        {
            SubCategory Subcategory = new SubCategory()
            {
                CategoryName = model.CategoryName,
                SubCategoryName = model.SubCategoryName,
                createdOn = DateTime.Now
            };
            _SubCategoryRepository.Insert(Subcategory);
            _SubCategoryRepository.Save();
            return RedirectToAction("Index");
        }
        public class DeleteModel
        {
            public int Id { get; set; }
        }
        [HttpPost]
        public ActionResult Delete(DeleteModel deleteModel)
        {
            var subCategoryRow = _SubCategoryRepository.GetById(deleteModel.Id);
            if (subCategoryRow != null)
            {
                _SubCategoryRepository.Delete(deleteModel.Id);
                _SubCategoryRepository.Save();
            }
            return View();
        }
       
        //[HttpGet]
        //public ActionResult Edit (int SubCategoryId)
        //{
        //    SubCategory subCategory = _SubCategoryRepository.GetById(SubCategoryId);
        //    return View(subCategory);
        //}
        //[HttpPost]
        //public ActionResult Edit(SubCategory model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.createdOn = DateTime.Now;
        //        _SubCategoryRepository.Update(model);
        //        _SubCategoryRepository.Save();
        //        return RedirectToAction("Index");
        //    }
        //}
    }


}