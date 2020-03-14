using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.ProWriter
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string HashedPassword { get; set; }
        public bool IsEmailVerified { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public virtual IList<Project> Projects { get; set; }
        public virtual IList<UserRole> UserRoles { get; set; }
        public virtual IList<UserSharedProject> UserSharedProjects { get; set; }
    }

    public class Role : Entity
    {
        public string Name { get; set; }

        public virtual IList<RoleClaim> Claims { get; set; }
    }

    public class RoleClaim : Entity
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }

    public class UserRole
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
