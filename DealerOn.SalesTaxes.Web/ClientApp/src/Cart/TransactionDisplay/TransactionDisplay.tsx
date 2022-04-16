import React from 'react';
// Types
import { Wrapper } from './TransactionDisplay.styles';
import { LineItem, SalesTransaction } from '../../App';
// Material
import Divider from '@material-ui/core/Divider'

type Props = {
  transaction: SalesTransaction;  
};

const TransactionReceipt: React.FC<Props> = ( { transaction }) => {

  let count: number = 0;

  function LineItemSeparator() {
    count++;
    if (count != transaction?.receipt.lineItems.length) {
      return <Divider variant="middle"/>
    }
  }

  function LineItemFormatter(lineItem: LineItem) {
    if (lineItem.quantity > 1)
      return <p>
                {lineItem.product.name}: {lineItem.product.price.toFixed(2)} 
                &nbsp; ({lineItem.quantity} @ {lineItem.totalCostPerItem.toFixed(2)})
             </p>
    else
      return <p>{lineItem.product.name}: {lineItem.product.price.toFixed(2)}</p>
  }

  return (
    <Wrapper>
      <div>
          <h2>Thank you for your purchase!</h2>
          {transaction?.receipt?.lineItems?.map(lineItem => (
            <div >
              {LineItemFormatter(lineItem)}
              {LineItemSeparator()}
            </div>
          ))}
          <hr/>
          <h4>Tax: ${transaction?.receipt.totalTax?.toFixed(2)}</h4>
          <h4>Total: ${transaction?.receipt.totalCost?.toFixed(2)}</h4>
        </div>
    </Wrapper>
  );
  //        }
};

export default TransactionReceipt;
