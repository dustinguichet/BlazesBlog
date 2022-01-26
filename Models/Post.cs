using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazeBlog.Models
{
  public class Post 
  {
        [DisplayName("User Name")]
        public string? UserName {get; set;}
        [DisplayName("Title")]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; } 
        [Required]
        [DisplayName("Time Stamp")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TimeStamp { get; set; }

        private DateTime _date = DateTime.Now;
        [Key]
        public int PostId { get; set; }
  }

    
}