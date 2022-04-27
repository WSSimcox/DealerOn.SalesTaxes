import Button from '@material-ui/core/Button';
// Types
import { Product } from '../App';
// Styles
import { Wrapper } from './LineItem.styles';

type Props = {
  product: Product;
};

const LineItem: React.FC<Props> = ({ product }) => (
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
        >
          -
        </Button>
        <p>{product.amount}</p>
        <Button
          size='small'
          disableElevation
          variant='contained'
        >
          +
        </Button>
      </div>
    </div>
  </Wrapper>
);

export default LineItem;
