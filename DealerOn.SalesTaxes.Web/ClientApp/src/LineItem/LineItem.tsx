import Button from '@material-ui/core/Button';
// Types
import { Product, ProductType } from '../App';
// Styles
import { Wrapper } from './LineItem.styles';

type Props = {
  product: Product;
  addToCart: (clickedItem: Product) => void;
  removeFromCart: (id: string) => void;
};

function renderSwitch(param: Product) {
  switch (param.type) {
    case ProductType.Other: {
      return <img src="images/Other.png" alt={param.name} />
    }
    case ProductType.Book: {
      return <img src="images/Book.png" alt={param.name} />
    }
    case ProductType.Food: {
      return <img src="images/Food.png" alt={param.name} />
    }
    case ProductType.Medical: {
      return <img src="images/Medical.png" alt={param.name} />
    }
    default: {
      return <img src="images/Other.png" alt={param.name} />
    }
  }
}

const LineItem: React.FC<Props> = ({ product, addToCart, removeFromCart }) => (
  <Wrapper>
    <div>
      <h3>{product.name}</h3>
      <div className='information'>
        <p>Price: ${product.price}</p>
        <p>Total: ${(product.amount * product.price).toFixed(2)}</p>
      </div>
      <div className='buttons'>
        <Button
          size='small'
          disableElevation
          variant='contained'
          onClick={() => removeFromCart(product.id)}
        >
          -
        </Button>
        <p>{product.amount}</p>
        <Button
          size='small'
          disableElevation
          variant='contained'
          onClick={() => addToCart(product)}
        >
          +
        </Button>
      </div>
    </div>
    {renderSwitch(product)}
  </Wrapper>
);

export default LineItem;
