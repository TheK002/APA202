namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class SliderUpdateVM
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
