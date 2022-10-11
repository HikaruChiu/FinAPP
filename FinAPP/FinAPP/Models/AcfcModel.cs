using System.ComponentModel.DataAnnotations;

namespace FinAPP.Models
{
    public class AcfcModel
    {
        [Key]
        public int Id { get; set; }
        
        public string Version { get; set; }
        public string Dept { get; set; }
        public decimal Actual { get; set; }
        public decimal Forecast { get; set; }
    }
}
