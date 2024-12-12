namespace Cart
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;

        // Constructor for Dependency Injection
        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        // GET: api/product/{cartId}
        [HttpGet("{cartId}")]
        public IActionResult getUserCart(int cartId)
        {
            Console.WriteLine($"Getting Cart by ID : {cartId}")
            var cart = _cartManager.getUserIdCart(cartId);
            if (cart == null)
            {
                Console.WriteLine("Unable to locate Cart.");
            }
            return OK(cart);
        }

        // GET: api/cart/cartId
        // GET: api/product
        // GET: api/cart/amount
        [HttpGet("{cartId}/{product}/{amount}")]
        public IActionResult addToCart(int cartId, Product product, int amount)
        {
            bool success = _cartManager.addToCart(cartId, product, amount);
            if (!success)
            {
                Console.WriteLine("Unable to add to cart");
            }
            return Ok(success);
        }

        // GET: api/cart/cartId
        // GET: api/product
        [HttpGet("{cartId}/{product}")]
        public IActionResult removeFromCart(int cartId, Product product)
        {
            bool success = _cartManager.removeFromCart(cartId, product);
            if (!success)
            {
                Console.WriteLine("Unable to remove from cart");
            }
            return Ok(success);
        }

        // GET: api/cart/cartId
        // GET: api/product
        // GET: api/cart/amount
        [HttpGet("{cartId}/{product}/{amount}")]
        public IActionResult updateAmount(int cartId, Product product, int amount)
        {
            bool success = _cartManager.updateAmount(cartId, product, amount);
            if (!success)
            {
                Console.WriteLine("Unable to update amount in cart");
            }
            return Ok(success);
        }

        // GET: api/cart
        [HttpGet("{cart}")]
        public IActionResult initiateCart(Cart cart)
        {
            bool success = _cartManager.initiateCart(cart);
            if (!success)
            {
                Console.WriteLine("Unable to initiate cart");
            }
            return Ok(success);
        }

        // GET: api/cart/cartId
        [HttpGet("{cartId}")]
        public IActionResult clearCart(int cartId)
        {
            bool success = _cartManager.clearCart(cartId);
            if (!success)
            {
                Console.WriteLine("Unable to clear cart");
            }
            return Ok(success);
        }
    }
}