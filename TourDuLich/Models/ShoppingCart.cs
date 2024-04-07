namespace nhom8_TourDuLich.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public void AddItem(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.ID_Tour ==item.ID_Tour);
            Items.Add(item);
        }

        public void RemoveItem(string productId)
        {
            Items.RemoveAll(i => i.ID_Tour.Equals(productId));
        }
    }


}
