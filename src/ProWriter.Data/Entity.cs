using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWriter.Data
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    // base entity
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
