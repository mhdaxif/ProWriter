using Microsoft.AspNetCore.Mvc;
using ProWriter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWriter.Web.Controllers
{
    [Route("documents")]
    public class DocumentsController : Controller
    {
        private AppDbContext _context;

        public DocumentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Documents.ToList();
            return View(list);
        }

        [HttpGet("detail")]
        public IActionResult Detail(int id)
        {
            var ent = _context.Documents.FirstOrDefault(x => x.Id == id);

            return View(ent);
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            var model = new Document();
            return View(model);
        }

        [HttpPost("create")]
        public ActionResult Create(Document model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var ent = _context.Documents.FirstOrDefault(x => x.Id == id);
                if (ent != null)
                {
                    _context.Documents.Remove(ent);

                    await _context.SaveChangesAsync();
                }

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
         
        //public override Task<IActionResult> Put(int id, [FromBody] Document dbEntity)
        //{
        //    return base.Put(id, dbEntity);
        //}
    }

}
