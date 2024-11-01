function solve(products) {

  function getProductsByCategory(category) {
    
    const filteredProducts = products.filter(product => product.category === category);
    return filteredProducts;

  }

  function addProduct(id, name, category, price, stock) {
    const newProduct= {id, name, category, price, stock}
    products.push(newProduct);
    return products;
  }

  function getProductById(id) {
    const foundProduct = products.find(product=> product.id === id)
    if(foundProduct == undefined)
      {
        return `Product with ID ${id} not found`;
      }
      else{
        return foundProduct;
      }
  }

  function removeProductById(id) {
    const indexRemovedProduct = products.findIndex(product=> product.id === id);
    if(indexRemovedProduct === -1)
      {
        return `Product with ID ${id} not found`;
      }
      else{     
        
        products.splice(indexRemovedProduct, 1)
       return products;
      }
  }

  function updateProductPrice(id, newPrice) {
    const product = products.find(product=> product.id === id);

    if(product){
      product.price = newPrice;
      return products;
    }
    else{
      return `Product with ID ${id} not found`;
    }
  }

  function updateProductStock(id, newStock) {
    const product = products.find(product=> product.id === id);

    if(product){
      product.stock = newStock;
      return products;
    }
    else{
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
  }
}

const products = [
  { id: 1, name: "Laptop", category: "Electronics", price: 1200, stock: 30 },
  { id: 2, name: "Smartphone", category: "Electronics", price: 800, stock: 50 },
  { id: 3, name: "Headphones", category: "Accessories", price: 150, stock: 100 }
];



const store= solve(products);
const productsWithNewStock= store.updateProductStock(8, 35);
console.log(JSON.stringify(productsWithNewStock))