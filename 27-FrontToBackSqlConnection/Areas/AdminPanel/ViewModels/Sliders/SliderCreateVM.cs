using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels 
{
    public class SliderCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]

        public string Subtitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public required IFormFile? Photo { get; set; }
    }
}
