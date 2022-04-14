import React from 'react';
// Types
import LineItem from '../../CartProduct/CartProduct';
import { Wrapper } from '../Cart.styles';
import { SalesTransaction } from '../../App';

type Props = {
  transaction: SalesTransaction;
};

const TransactionReceipt: React.FC = ({ }) => {

  return (
    <Wrapper>
        {/* <h2>Thank you for your purchase!</h2>
        {products.length === 0 ? <p>No items in cart.</p> : null}
        {products.map(product => (
          <LineItem
            key={product.id}
            product={product}
            addToCart={addToCart}
            removeFromCart={removeFromCart}
          />
        ))}
        <h2>Tax: ${100}</h2>
        <h2>Total: ${1000}</h2> */}
    </Wrapper>
  );
};

export default TransactionReceipt;
