using Microsoft.AspNetCore.Mvc;
using ProWriter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWriter.Web.Controllers
{
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

        //public override IActionResult Index(int id)
        //{
        //    return base.Index(id);
        //}

        //public override Task<IActionResult> Put(int id, [FromBody] Document dbEntity)
        //{
        //    return base.Put(id, dbEntity);
        //}

        //public override Task<ActionResult<Document>> Post([FromBody] Document dbEntity)
        //{
        //    return base.Post(dbEntity);
        //}

        //public override Task<ActionResult<Document>> Delete(int id)
        //{
        //    return base.Delete(id);
        //}
    }
}
