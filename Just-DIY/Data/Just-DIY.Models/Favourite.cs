using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Just_DIY.Models
{
    public class Favourite
    {
        [Key, Column(Order = 0)]
        public int UserId
        {
            get; set;
        }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Key, Column(Order =1)]
        public int ProjectId
        {
            get; set;
        }
        
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
