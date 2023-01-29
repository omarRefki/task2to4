using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace task2.Models
{
    public class department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dnum { get; set; }
        public string? DName { get; set; }

        public virtual List<project>? Projects { get; set; } = new List<project>();

        public virtual List<location>? DLocations { get; set; } = new List<location>();
        public virtual List<employee>? Employees { get; set; } = new List<employee>();
        [ForeignKey("Employee")]
        public int? MangerId { get; set; }
        public virtual employee? Employee { get; set; }
        public DateTime? hireDate { get; set; }

    }
}
