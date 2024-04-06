namespace _2180607445_HaMinhDuc.Models
{
	public class ProductImages
	{
		public int Id { get; set; }// đã sửa đổi để id không tăng tự động hoặc có thể chưa nội dung url :V 
		public string Url { get; set; }
		public int ProductId { get; set; }
		public Product? Product { get; set; }
	}
}
