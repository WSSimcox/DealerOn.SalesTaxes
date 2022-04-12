import Button from '@material-ui/core/Button';
import ClearButton from '@material-ui/icons/Clear';
// Types
import { ProductType, ProductEnumType } from '../App';
// Styles
import { Wrapper, StyledClearButton } from './Product.styles';

type Props = {
  product: ProductType;
  handleAddToCart: (clickedItem: ProductType) => void;
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

const Product: React.FC<Props> = ({ product, handleAddToCart }) => (
  <Wrapper>
    <StyledClearButton>
      <ClearButton />
    </StyledClearButton>
    {renderSwitch(product)}
    <div>
      <h3>{product.name}</h3>
      <p>{product.description}</p>
      <h3>${product.price.toFixed(2)}</h3>
    </div>
    <Button onClick={() => handleAddToCart(product)}>Add to cart</Button>
  </Wrapper>
);

export default Product;
