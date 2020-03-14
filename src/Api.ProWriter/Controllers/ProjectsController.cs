using Data.ProWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ProWriter.Controllers
{
    public class ProjectsController : BaseController<AppDbContext, Project>
    {
        public ProjectsController(AppDbContext context) : base(context, context.Projects) { }

    }
}
