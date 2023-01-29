using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class workon
    {
        [ForeignKey("Employee")]
        public int? ESSN { get; set; }
        [ForeignKey("Project")]
        public int? Pnum { get; set; }
        public int? hour { get; set; }

        public virtual project? Project { get; set; }
        public virtual employee? Employee { get; set; }
    }
}
