import Button from '@material-ui/core/Button';
import DeleteForever from '@material-ui/icons/DeleteForever';
// Types
import { Product, ProductType } from '../App';
// Styles
import { Wrapper, StyledDeleteButton } from './Product.styles';

type Props = {
  product: Product;
  handleAddToCart: (clickedItem: Product) => void;
  handleDeleteProduct: (clickedItem: Product) => void;
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

const ProductCard: React.FC<Props> = ({ product, handleAddToCart, handleDeleteProduct }) => (
  <Wrapper>
    <div id="deleteContainer">
      <StyledDeleteButton>
        <DeleteForever onClick={() => handleDeleteProduct(product)}></DeleteForever>
      </StyledDeleteButton>
    </div>
    {renderSwitch(product)}
    <div>
      <h3>{product.name}</h3>
      <p>{product.description}</p>
      <h3>${product.price.toFixed(2)}</h3>
    </div>
    <Button onClick={() => handleAddToCart(product)}>Add to cart</Button>
  </Wrapper>
);

export default ProductCard;
