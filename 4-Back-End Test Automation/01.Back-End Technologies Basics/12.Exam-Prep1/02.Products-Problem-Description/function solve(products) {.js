function solve(products) {
  
  // Filter products by category
  function getProductsByCategory(category) {
    return products.filter(product => product.category === category);
  }

  // Add a new product
  function addProduct(id, name, category, price, stock) {
    products.push({ id, name, category, price, stock });
    return products;
  }

  // Find product by ID
  function getProductById(id) {
    const product = products.find(product => product.id === id);
    return product || `Product with ID ${id} not found`;
  }

  // Remove product by ID
  function removeProductById(id) {
    const index = products.findIndex(product => product.id === id);
    if (index !== -1) {
      products.splice(index, 1);
      return products;
    } else {
      return `Product with ID ${id} not found`;
    }
  }

  // Update product price
  function updateProductPrice(id, newPrice) {
    const product = products.find(product => product.id === id);
    if (product) {
      product.price = newPrice;
      return products;
    } else {
      return `Product with ID ${id} not found`;
    }
  }

  // Update product stock
  function updateProductStock(id, newStock) {
    const product = products.find(product => product.id === id);
    if (product) {
      product.stock = newStock;
      return products;
    } else {
      return `Product with ID ${id} not found`;
    }
  }

  return {
    getProductsByCategory,
    addProduct,
    getProductById,
    removeProductById,
    updateProductPrice,
    updateProductStock
  };
}
