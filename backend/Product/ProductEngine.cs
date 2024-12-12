namespace Product
{
  public class ProductEngine : IProductEngine
  {
    private readonly IProductAccessor _productAccessor;

    public ProductEngine(IProductAccessor productAccessor)
    {
      _productAccessor = productAccessor;
    }

    public Product GetProductById(int productId)
    {
      var product = _productAccessor.GetProductById(productId);
      if (product == null)
      {
        throw new ArgumentException($"No product found with ID {productId}");
      }
      return product;
    }
    public Product GetProductByName(string Name)
    {
      var product = _productAccessor.GetProductByName(Name);
      if (product == null)
      {
        throw new ArgumentException($"No product found with Name {Name}");
      }
      return product;
    }
    public List<Product> GetProductByCategory(int categoryId)
    {
      return _productAccessor.GetProductByCategory(categoryId);
    }

    public List<Product> GetAllProducts()
    {
      return _productAccessor.GetAllProducts();
    }

    public bool UpdateProductStock(int productId, int stock)
    {
      if (stock < 0)
      {
        throw new ArgumentException("Stock cannot be negative.");
      }

      return _productAccessor.UpdateProductStock(productId, stock);
    }
  }
}