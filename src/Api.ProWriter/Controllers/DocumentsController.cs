using Data.ProWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ProWriter.Controllers
{
    public class DocumentsController : BaseController<AppDbContext, Document>
    {
        public DocumentsController(AppDbContext context) : base(context, context.Documents) { }

    }
}
