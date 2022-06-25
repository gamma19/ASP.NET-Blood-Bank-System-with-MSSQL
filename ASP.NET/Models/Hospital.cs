using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Final2.Models
{
    public class Hospital
    {
        [Key]
        public int hId { get; set; }
        public string hName { get; set; }
        public string hAddress { get; set; }
    }
}
