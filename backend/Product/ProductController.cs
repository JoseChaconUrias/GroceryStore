namespace Product
{

  using Microsoft.AspNetCore.Mvc;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductManager _productManager;

    public ProductController(IProductManager productManager)
    {
      _productManager = productManager;
    }

    // GET: api/product/id/{id}
    [HttpGet("id/{id}")]
    public IActionResult GetProductById(int id)
    {
      Console.WriteLine($"Getting product by ID: {id}");
      var product = _productManager.GetProductById(id);
      if (product == null)
      {
        return NotFound("Product not found.");
      }
      return Ok(product);
    }

    // GET : api/product/name/{name}
    [HttpGet("name/{name}")]
    public IActionResult GetProductByName(string name) 
    {
        try
        {
            Console.WriteLine($"Getting product by Name: {name}");
            var product = _productManager.GetProductByName(name);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    // GET: api/product/category/{id}
    [HttpGet("category/{id}")]
    public IActionResult GetProductByCategory(int id) 
    {
      Console.WriteLine($"Getting product by Category: {id}");
      var products = _productManager.GetProductByCategory(id);
      return Ok(products);
    }
    
    // GET: api/product
    [HttpGet]
    public IActionResult GetAllProducts()
    {
      var products = _productManager.GetAllProducts();
      return Ok(products);
    }

    // PUT: api/product/update-stock
    [HttpPut("update-stock")]
    public IActionResult UpdateProductStock([FromBody] UpdateStockRequest request)
    {
      var success = _productManager.UpdateProductStock(request.ProductId, request.Stock);
      if (!success)
      {
        return BadRequest("Failed to update stock.");
      }
      return Ok("Stock updated successfully.");
    }
  }

  // Request models for updating stock and discount
  public class UpdateStockRequest
  {
    public int ProductId { get; set; }
    public int Stock { get; set; }
  }

}
