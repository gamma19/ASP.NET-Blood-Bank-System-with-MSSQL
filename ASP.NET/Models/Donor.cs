using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Final2.Models
{
    public class Donor
    {
        [Key]
        public int dSsn { get; set; }

        public string dGender { get; set; }
        public string dName { get; set; }
        public string dLastName { get; set; }

    }
}
