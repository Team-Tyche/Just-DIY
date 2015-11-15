namespace Just_DIY.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Project
    {
        private ICollection<Vote> votes;
        private ICollection<Favourite> favourites;

        public Project()
        {
            this.votes = new HashSet<Vote>();
            this.favourites = new HashSet<Favourite>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string Content { get; set; }

        public string VideoUrl { get; set; }
        
        public int? AuthorId { get; set; }

        public int Points { get; set; }
        
        public virtual User Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Favourite> Favourite
        {
            get { return this.favourites; }
            set { this.favourites = value; }
        }
    }
}
