import Button from '@material-ui/core/Button';
// Types
import { ProductType, ProductEnumType } from '../App';
// Styles
import { Wrapper } from './LineItem.styles';

type Props = {
  product: ProductType;
  addToCart: (clickedItem: ProductType) => void;
  removeFromCart: (id: string) => void;
};

function renderSwitch(param: ProductType) {
  switch (param.type) {
    case ProductEnumType.Other: {
      return <img src="images/Other.png" alt={param.name} />
    }
    case ProductEnumType.Book: {
      return <img src="images/Book.png" alt={param.name} />
    }
    case ProductEnumType.Food: {
      return <img src="images/Food.png" alt={param.name} />
    }
    case ProductEnumType.Medical: {
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
