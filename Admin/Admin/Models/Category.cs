namespace Admin.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Tour>? Tours { get; set; }
    }
}
