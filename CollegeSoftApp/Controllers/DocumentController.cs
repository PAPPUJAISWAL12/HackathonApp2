using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeSoftApp.Controllers
{
    public class DocumentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var Doclist = await DataAccess.GetDocument();
            return View(Doclist);
        }
        public IActionResult Edit()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            List<DocumentView>? documentViews=await DataAccess.GetDocument();
            return PartialView(documentViews);
        }
        [HttpGet]
        public async Task<IActionResult> create()
        {
            List<Upload> uploads = await UploadAccess.GetUpload();
            ViewBag.uList = new SelectList(uploads, nameof(Upload.UploadId), nameof(Upload.DocumentType));
            return PartialView(uploads);
        }
        [HttpPost]
        public async Task<IActionResult> create(Document docview)
        {
            await DataAccess.CreateDocument(docview);
            return RedirectToAction("index");
        }
    }
}
