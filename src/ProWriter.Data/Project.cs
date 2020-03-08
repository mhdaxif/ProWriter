using System.Collections.Generic;

namespace ProWriter.Data
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IList<Document> Documents { get; set; }
        public virtual IList<UserSharedProject> UserSharedProjects { get; set; }
    }
}
