namespace Cart
{
    public class CartManager : ICartManager
    {
        private readonly ICartEngine _cartEngine;

        public ProductManager(ICartEngine cartEngine)
        {
            _cartEngine = cartEngine;
        }

        Cart getUserCart(int cartId)
        {
            return _cartEngine.GetUserCart(cartId);
        }

        bool addToCart(int cartId, Product product, int amount)
        {
            return _cartEngine.addToCart(cartId, product, amount);
        }

        bool removeFromCart(int cartId, Product product)
        {
            return _cartEngine.removeCart(cartId, product);
        }

        bool updateAmount(int cartId, Product product, int amount)
        {
            return _cartEngine.updateAmount(cartId, product, amount);
        }

        bool initiateCart(Cart cart)
        {
            return _cartEngine.initiateCart(cart);
        }

        bool clearCart(int cartId)
        {
            return _cartEngine.clearCart(cartId);
        }
    }
}