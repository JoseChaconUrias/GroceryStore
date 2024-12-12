namespace Cart
{
    public interface ICartManager
    {
        Cart getUserCart(int cartId);
        bool addToCart(int cartId, Product product, int amount);
        bool removeFromCart(int cartId, Product product);
        bool updateAmount(int cartId, Product product, int amount);
        bool initiateCart(Cart cart);
        bool clearCart(int cartId);
    }
}