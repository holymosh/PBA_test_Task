using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class Department:AbstractEntity
    {
        [Required]
        public string Title { get; set; }
    }
}
