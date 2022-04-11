import LineItem from '../LineItem/LineItem';
import { Wrapper, Button } from './Cart.styles';
import { ProductType } from '../App';

type Props = {
  products: ProductType[];
  addToCart: (clickedItem: ProductType) => void;
  removeFromCart: (id: string) => void;
};

const Cart: React.FC<Props> = ({ products, addToCart, removeFromCart }) => {
  const calculateTotal = (items: ProductType[]) =>
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
      <Button>Checkout Cart</Button>
    </Wrapper>
  );
};

export default Cart;
