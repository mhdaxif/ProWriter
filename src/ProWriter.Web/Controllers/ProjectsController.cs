using Microsoft.AspNetCore.Mvc;
using ProWriter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWriter.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Projects.ToList();
            return View(list);
        }

        public IActionResult Detail(int id)
        {
            return View();
        }

        [HttpGet("create")]
        public ActionResult Post()
        {
            var model = new Project();
            return View(model);
        }

        [HttpPost("create")]
        public ActionResult Post(Project model)
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
                var ent = _context.Projects.FirstOrDefault(x => x.Id == id);
                if (ent != null)
                {
                    _context.Projects.Remove(ent);

                    await _context.SaveChangesAsync();
                }

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        //public override Task<IActionResult> Put(int id, [FromBody] Project dbEntity)
        //{
        //    return base.Put(id, dbEntity);
        //}
    }

}
