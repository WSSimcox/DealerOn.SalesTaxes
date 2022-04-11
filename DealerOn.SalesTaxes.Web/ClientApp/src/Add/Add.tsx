import CartItem from '../LineItem/LineItem';
import { Wrapper } from './Add.styles';
import { ProductType } from '../App';

type Props = {
  cartItems: ProductType[];
  addToCart: (clickedItem: ProductType) => void;
  removeFromCart: (id: string) => void;
};

const Add: React.FC<Props> = ({ cartItems, addToCart, removeFromCart }) => {
  const calculateTotal = (items: ProductType[]) =>
    items.reduce((ack: number, item) => ack + item.amount * item.price, 0);

  return (
    <Wrapper>
      <h2>Add Product To Catalog</h2>
    </Wrapper>
  );
};

export default Add;
