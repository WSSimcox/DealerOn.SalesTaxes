import React from 'react';
// Types
import { Wrapper } from '../Cart.styles';
import { LineItem } from '../../App';

type Props = {
  lineItems: LineItem[];
};

const TransactionReceipt: React.FC<Props> = ( { lineItems }) => {

  

  return (
    <Wrapper>
        <h2>Thank you for your purchase!</h2>
        {lineItems.map(lineItem => (
          <div>
            <h4>{lineItem.productId}</h4>
            <h4>{lineItem.productName}</h4>
            <h4>{lineItem.quantity}</h4>
            <br/>
          </div>
        ))}
        <h2>Tax: ${100}</h2>
        <h2>Total: ${1000}</h2>
    </Wrapper>
  );
};

export default TransactionReceipt;
