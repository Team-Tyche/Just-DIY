﻿namespace Just_DIY.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        //TODO: ??? VoteId
        public int Votes { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
