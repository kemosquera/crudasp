using MvcCrudApp.Models;

namespace MvcCrudApp.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Create(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }

        public bool Update(int id, Product updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null) return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}