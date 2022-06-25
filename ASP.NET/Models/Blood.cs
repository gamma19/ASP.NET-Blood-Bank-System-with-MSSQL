using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final2.Models
{
    public class Blood
    {  
        //----Foreign keys----
        [ForeignKey("dSsn")]
        public int dSsn { get; set; }
        
        [ForeignKey("hId")]
        public int hId { get; set; }
        
        [ForeignKey("bbId")]
        public int bbId { get; set; }
        
        [ForeignKey("sSsn")]
        public int sSsn { get; set; }
        //------------
        public string bType { get; set; }
        public string rhType { get; set; }
        [Key]
        public int bTubeid { get; set; }
        public int bAmount { get; set; }


    }
}
