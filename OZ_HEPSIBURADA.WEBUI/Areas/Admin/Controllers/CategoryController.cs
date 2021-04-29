using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using OZ_HEPSIBURADA.BLL.Services;
using Excel = Microsoft.Office.Interop.Excel;
using OZ_HEPSIBURADA.BLL.Model_DTO;
using OZ_HEPSIBURADA.WEBUI.Controllers;
using OZ_HEPSIBURADA.DAL.UnifOfWork;
using System.IO;

namespace OZ_HEPSIBURADA.WEBUI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryService cs;
        private readonly IUnitOfWork _iuow;
        private readonly string exportPath = String.Concat(AppDomain.CurrentDomain.BaseDirectory, 
            "Areas\\Admin\\Documents\\Exported\\CategoryReport.xls");

        public CategoryController(IUnitOfWork IUOW, CategoryService CS)
            : base(IUOW)
        {
            _iuow = IUOW;
            cs = CS;
        }

        // GET: /Admin/Category/

        public ActionResult ListAllCategories()
        {
            return View(cs.GetAllCategoryDTO());
        }

        [HttpPost]
        public JsonResult InsertCategory(CategoryDTO insertedDTO)
        {
            cs.InsertCategoryDTO(insertedDTO);
            _iuow.SaveChanges();

            return Json(new { redirectToUrl = Url.Action("ListAllCategories", "Category") });
        }

        [HttpPost]
        public JsonResult UpdateCategory(CategoryDTO updatedCatDTO)
        {
            cs.UpdateCategoryDTO(updatedCatDTO);
            _iuow.SaveChanges();

            return Json(new { redirectToUrl = Url.Action("ListAllCategories", "Category") }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult HardDeleteCategory(int hdnDeletedCatId)
        {
            cs.HardDeleteCategoryDTO(hdnDeletedCatId);
            _iuow.SaveChanges();

            return RedirectToAction("ListAllCategories", "Category");
        }

        public ActionResult ExcelExport()
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Missing.Value);
            Excel.Worksheet ws = wb.ActiveSheet;

            ws.Cells[1, 1] = "Order No";
            ws.Cells[1, 2] = "Category Name";
            ws.Cells[1, 3] = "Category Description";

            int row = 2;
            foreach (CategoryDTO item in cs.GetAllCategoryDTO())
            {
                ws.Cells[row, 1] = row - 1;
                ws.Cells[row, 2] = item.DTOName;
                ws.Cells[row, 3] = item.DTODesc;
                row++;
            }

            ws.Columns.AutoFit();
            wb.SaveAs(exportPath);

            return RedirectToAction("ListAllCategories", "Category");
        }

        public ActionResult ExcelImport()
        {
            return View();
        }

        public ActionResult ImportResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExcelImport(HttpPostedFileBase documentLoaded)
        {
            // documentLoaded is the input name in the import modal's form.
            List<CategoryDTO> categoryDtoList = new List<CategoryDTO>();
            string fileName = documentLoaded.FileName.Split('.')[0] + "_" + DateTime.Now.ToShortDateString();
            string fileExtension = documentLoaded.FileName.Split('.')[1];

            if (documentLoaded.FileName.EndsWith("xls") || documentLoaded.FileName.EndsWith("xlsx"))
            {
                string path = Server.MapPath("~/Areas/Admin/Documents/Sample/" + fileName + "." + fileExtension);
                documentLoaded.SaveAs(path);

                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(path);
                Excel.Worksheet ws = wb.ActiveSheet;
                Excel.Range range = ws.UsedRange;

                for (int i = 2; i <= range.Rows.Count; i++)
                {
                    CategoryDTO newCatDto = new CategoryDTO()
                    {
                        DTOName = ((Excel.Range)range[i, 2]).Text,
                        DTODesc = ((Excel.Range)range[i, 3]).Text
                    };
                    categoryDtoList.Add(newCatDto);
                }
            }

            ViewBag.CreatedDTOList = categoryDtoList;

            return View("ImportResult");
        }
    }
}
