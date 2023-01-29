using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class dependent
    {
        public string name { get; set; }
        public string? sex { get; set; }
        [Column(TypeName = "date")]
        public DateTime? date { get; set; }
        public string relationship { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeSSN { get; set; }
        public virtual employee? Employee { get; set; }
    }
}
