using MVCAssignment.Models;
using MVCAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAssignment.Controllers
{
    public class TempModel
    {
        public string Name { get; set; }
    }

    public class ProductController : Controller
    {
        // GET: Product
        public readonly IGenericRepositary<Product> _ProductRepository;
        public readonly IGenericRepositary<SubCategory> _SubCategoryRepository;
        public readonly IGenericRepositary<Category> _categoryRepository;
        public ProductController()
        {
            _ProductRepository = new GenericRepository<Product>();
            _SubCategoryRepository = new GenericRepository<SubCategory>();
            _categoryRepository = new GenericRepository<Category>();
        }

        public ActionResult Index()
        {
            var Productdata = _ProductRepository.GetAll();
            var cat = _categoryRepository.GetAll();
            ViewBag.Category = cat;
            return View(Productdata);
        }

        [HttpPost]
        public JsonResult GetSubCategory(TempModel model)
        {
            List<SelectListItem> SubCategory = new List<SelectListItem>();
            var subCat = _SubCategoryRepository.GetAll().Where( x => x.CategoryName==model.Name);
        
            var data = subCat.Select(m => new SelectListItem()
            {
                Text = m.SubCategoryName,
                Value = m.SubCategoryId.ToString()
            });
            return Json(data , JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Insert(Product model)
        {
            Product product = new Product()
            {
                CategoryName = model.CategoryName,
                SubCategoryName= model.SubCategoryName,
                ProductName= model.ProductName,
                ProductPrice= model.ProductPrice,
                CreadtedDate = DateTime.Now
            };
            _ProductRepository.Insert(product);
            _ProductRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var productRow = _ProductRepository.GetById(id);
            if (productRow != null)
            {
                _ProductRepository.Delete(id);
                _ProductRepository.Save();
            }
            return View();
        }


    }
}