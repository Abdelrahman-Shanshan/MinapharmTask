using MinapharmTask.Data;
using MinapharmTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MinapharmTask.Controllers
{
    public class AssetsController : Controller
    {
        private readonly AppDBContext _context;
        public AssetsController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<AssetsAttributes> objAssetlist = _context.AssetsAttributes;
            return View(objAssetlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AssetsAttributes assetobj)
        {
            if (ModelState.IsValid)
            {
                _context.AssetsAttributes.Add(assetobj);
                _context.SaveChanges();
                //TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(assetobj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var assetfromdb = _context.AssetsAttributes.Find(id);

            if (assetfromdb == null)
            {
                return NotFound();
            }
            return View(assetfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AssetsAttributes assetobj)
        {
            if (ModelState.IsValid)
            {
                _context.AssetsAttributes.Update(assetobj);
                _context.SaveChanges();
               // TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(assetobj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var assetfromdb = _context.AssetsAttributes.Find(id);

            if (assetfromdb == null)
            {
                return NotFound();
            }
            return View(assetfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAsset(int? id)
        {
            var deleterecord = _context.AssetsAttributes.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.AssetsAttributes.Remove(deleterecord);
            _context.SaveChanges();
            //TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public List<AssetsAttributes> Search(string searchKeyword)
        {
            var result = new List<AssetsAttributes>();
            try
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    result = _context.AssetsAttributes.Where(x => x.AssetName.Contains(searchKeyword)).ToList();
                }
                else
                {
                    result = _context.AssetsAttributes.ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

    }
}
