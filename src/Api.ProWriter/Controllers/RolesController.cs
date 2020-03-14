using Data.ProWriter;

namespace Api.ProWriter.Controllers
{
    public class RolesController : BaseController<AppDbContext, Role>
    {
        public RolesController(AppDbContext context) : base(context, context.Roles) { }

    }

}
