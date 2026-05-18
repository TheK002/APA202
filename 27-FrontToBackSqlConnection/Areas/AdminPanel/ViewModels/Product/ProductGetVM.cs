using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product
{
    public class ProductGetVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string? CategoryName { get; set; }
        public string? Image { get; set; }
        public int Id { get; internal set; }
    }
}
