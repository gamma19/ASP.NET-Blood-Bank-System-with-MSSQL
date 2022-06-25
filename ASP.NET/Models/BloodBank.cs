using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Final2.Models
{
    public class BloodBank
    {
        [Key]
        public int bbId { get; set; }
        public string bbName { get; set; }
        public string bbAddress { get; set; }

    }
}
