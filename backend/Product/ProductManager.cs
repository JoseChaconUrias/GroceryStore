namespace Product
{
  public class ProductManager : IProductManager
  {
    private readonly IProductEngine _productEngine;

    public ProductManager(IProductEngine productEngine)
    {
      _productEngine = productEngine;
    }

    public Product GetProductById(int productId)
    {
      return _productEngine.GetProductById(productId);
    }
    public Product GetProductByName(string Name)
    {
      return _productEngine.GetProductByName(Name);
    }
    public List<Product> GetProductByCategory(int categoryId)
    {
      return _productEngine.GetProductByCategory(categoryId);
    }

    public List<Product> GetAllProducts()
    {
      return _productEngine.GetAllProducts();
    }

    public bool UpdateProductStock(int productId, int stock)
    {
      return _productEngine.UpdateProductStock(productId, stock);
    }
  }
}