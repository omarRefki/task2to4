using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class location
    {
        public string? Dlocation { get; set; }

        [ForeignKey("Department")]
        public int? Dnum { get; set; }
        public virtual department? Department { get; set; }
    }
}
