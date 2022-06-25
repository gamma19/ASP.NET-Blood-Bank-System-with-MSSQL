using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final2.Models
{
    public class Seeker
    {
        [Key]
        public int sSsn { get; set; }
        public string sGender { get; set; }
        public string sName { get; set; }
        public string sLastName { get; set; }

    }
}
