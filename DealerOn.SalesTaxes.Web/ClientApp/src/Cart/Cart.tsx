import React from 'react';
// Types
import CartProduct from '../CartProduct/CartProduct';
import { Wrapper } from './Cart.styles';
import { Product, LineItem } from '../App';
// Material
import Button from '@mui/material/Button';
import TransactionDisplay from './TransactionDisplay/TransactionDisplay';
import { render } from 'react-dom';

type Props = {
  products: Product[];
  addToCart: (clickedItem: Product) => void;
  removeFromCart: (id: string) => void;
  checkoutClicked: () => void;
};

const Cart: React.FC<Props> = ({ products, addToCart, removeFromCart, checkoutClicked }) => {

  const[receiptVisible, setReceiptVisible] = React.useState(false); 
  const[transactionItems, setTransactionItems] = React.useState([] as LineItem[]); 

  function handleCheckout() {
    setReceiptVisible(true);
    generateLineItems();
    EmptyCart();
  };
  
  function generateLineItems() { 
    let lineItems = Array<LineItem>();

    products.forEach((p) => {
      let lineItem = {} as LineItem;
      lineItem.productId = p.id;
      lineItem.productName = p.name;
      lineItem.quantity = p.amount;
      lineItems.push(lineItem);
      transactionItems.push(lineItem);
    });

    setTransactionItems(transactionItems);

    return transactionItems;
  };

  function EmptyCart() {
    products.forEach((p) => {
      removeFromCart(p.id);
    });
  }

  const calculateTotal = (items: Product[]) =>
    items.reduce((ack: number, item) => ack + item.amount * item.price, 0);

  return (
    <Wrapper>
      <div className={receiptVisible ? 'hidden' : 'undefined'}>
        <h2>Your Shopping Cart</h2>
        {products.length === 0 ? <p>No items in cart.</p> : undefined }
        {products.map(product => (
          <CartProduct
            key={product.id}
            product={product}
            addToCart={addToCart}
            removeFromCart={removeFromCart}
          />
        ))}
        <div className={products.length === 0 ? 'hidden' : undefined}>
          <h2>Total: ${calculateTotal(products).toFixed(2)}</h2>
          <p>Tax calculated at checkout.</p>
          <Button variant="contained" onClick={() => checkoutClicked()}>Checkout</Button>
        </div>
      </div>
    </Wrapper>
  );
};

export default Cart;
