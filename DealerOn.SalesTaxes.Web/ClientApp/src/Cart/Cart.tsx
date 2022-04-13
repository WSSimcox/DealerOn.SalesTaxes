import LineItem from '../LineItem/LineItem';
import { Wrapper } from './Cart.styles';
import { Product } from '../App';
import { Button } from '@material-ui/core';

type Props = {
  products: Product[];
  addToCart: (clickedItem: Product) => void;
  removeFromCart: (id: string) => void;
};

const Cart: React.FC<Props> = ({ products, addToCart, removeFromCart }) => {
  const calculateTotal = (items: Product[]) =>
    items.reduce((ack: number, item) => ack + item.amount * item.price, 0);

  return (
    <Wrapper>
      <h2>Your Shopping Cart</h2>
      {products.length === 0 ? <p>No items in cart.</p> : null}
      {products.map(product => (
        <LineItem
          key={product.id}
          product={product}
          addToCart={addToCart}
          removeFromCart={removeFromCart}
        />
      ))}
      <h2>Total: ${calculateTotal(products).toFixed(2)}</h2>
      <p>Tax calculated at checkout.</p>
      <Button variant="contained">Checkout</Button>
      &nbsp; &nbsp;
      <Button variant="outlined">Close</Button>
    </Wrapper>
  );
};

export default Cart;
