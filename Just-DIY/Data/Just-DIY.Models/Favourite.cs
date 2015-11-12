using System.ComponentModel.DataAnnotations;

namespace Just_DIY.Models
{
    public class Favourite
    {
        [Key]
        public int UserId
        {
            get; set;
        }

        public virtual User User { get; set; }

        [Key]
        public int ProjectId
        {
            get; set;
        }

        public virtual Project Project { get; set; }
    }
}
