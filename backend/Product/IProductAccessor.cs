namespace Product
{
  public interface IProductAccessor
  {
    public Product GetProductById(int productId);
    public Product GetProductByName(string Name);
    public List<Product>GetProductByCategory(int categoryId);
    public List<Product> GetAllProducts();
    public bool UpdateProductStock(int productId, int stock);
  }
}