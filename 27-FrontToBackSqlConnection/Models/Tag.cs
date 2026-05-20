namespace _27_FrontToBackSqlConnection.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductTag> ProductsTags { get; set; }
    }
}
