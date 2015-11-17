using System;
using System.ComponentModel.DataAnnotations;

namespace Just_DIY.Models.Projects
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime? CreatedOn { get; set; }

        public string Content { get; set; }

        public string VideoUrl { get; set; }

        public SimpleUser Author { get; set; }

        public string Category { get; set; }

        public int Points { get; set; }
    }
}