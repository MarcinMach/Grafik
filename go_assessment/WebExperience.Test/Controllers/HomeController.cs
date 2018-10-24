using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExperience.Test.Bussines_Logic;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            FilesManager.SaveFileToDatabase();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region GetList()
        [HttpPost]
        public JsonResult GetList(int page = 1, int size = 10)
        {
            var list = FilesManager.GetFilesList();
            int rowCount = list.Count();
            var pageSkip = page > 0 ? page - 1 : page;
            var results = list.Skip<FileModel>(pageSkip * size)
                .Take<FileModel>(size)
                .ToList();
            return Json(new { RowCount = rowCount, Results = results, Total = list }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete()
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            FilesManager.Delete(id);
            return Json(true);
        }
        #endregion

        #region Edit()
        [HttpPost]
        public JsonResult Edit(Guid id)
        {
            var record = FilesManager.GetById(id);
            return Json(record);
        }
        #endregion

        #region Update()
        [HttpPost]
        public JsonResult Update(Guid id, string fileName, string createdBy, string mimeType, string country, string description, string email)
        {
            var model = new FileModel(id, fileName, createdBy, mimeType, country, description, email);
            var record = FilesManager.Update(model);
            return Json(record);
        }
        #endregion

        #region Dwonload()
        [HttpPost]
        public JsonResult Dwonload()
        {
            var record = FilesManager.SaveFileToDatabase();
            return Json(record);
        }
        #endregion
    }
}


