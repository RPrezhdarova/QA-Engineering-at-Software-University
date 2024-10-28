function storeProvision(currentStock, orderedProducts){
    let store ={};
    for(let i=0; i<currentStock.length; i+=2){
        let productName=currentStock[i];
        let productQuantity = Number(currentStock[i+1]);

        store[productName] = productQuantity;
    }   
    for(let i=0; i<orderedProducts.length; i+=2){
        let productName=orderedProducts[i];
        let productQuantity=Number(orderedProducts[i+1]);

        if(store.hasOwnProperty(productName)){
            store[productName]+=productQuantity;
        }
        else{
            store[productName]=productQuantity;
        }
    }
    for(let product in store){
        console.log(`${product} -> ${store[product]}`);
    }
}
