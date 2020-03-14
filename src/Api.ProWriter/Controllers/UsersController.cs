using Data.ProWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ProWriter.Controllers
{
    public class UsersController : BaseController<AppDbContext, User>
    {
        public UsersController(AppDbContext context) : base(context, context.Users) { }
    }
} 