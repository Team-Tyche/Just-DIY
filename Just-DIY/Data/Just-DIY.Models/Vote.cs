﻿namespace Just_DIY.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vote
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        
        public virtual User User { get; set; }

        [Key, Column(Order = 1)]
        public int ProjectId { get; set; }
        
        public virtual Project Project { get; set; }

        public int Value { get; set; }
    }
}
