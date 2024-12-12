namespace Cart {

    public class Cart
    {
        public required int cartId { get; set; }
        public required int userId { get; set; }
        public required SortedDictionary<int, int> itemList { get; set; }
        public required double totalPrice { get; set; }
    }
}