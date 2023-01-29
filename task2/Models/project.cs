using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace task2.Models
{
    public class project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pnumber { get; set; }
        public string? Name { get; set; }
        public string? location { get; set; }

        public int? DepartmentDnum { get; set; }
        public virtual department? Department { get; set; }
        public virtual List<workon>? WorkOns { get; } = new List<workon>();

    }
}
