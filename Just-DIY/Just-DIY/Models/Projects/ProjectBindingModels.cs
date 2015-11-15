using System;
using System.ComponentModel.DataAnnotations;

namespace Just_DIY.Models.Projects
{
    public class CreateBindingModel
    {
        [Required]
        public string Name { get; set; }
        
        public DateTime? CreatedOn { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}