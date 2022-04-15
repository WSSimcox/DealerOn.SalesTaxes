import React from 'react';
import { useQuery } from 'react-query';
// Types
import { Wrapper } from './TransactionDisplay.styles';
import { LineItem, SalesTransaction } from '../../App';
import { transactionEndpoint } from '../../ApiClient';
// Material
import Divider from '@material-ui/core/Divider'
import LinearProgress from '@material-ui/core/LinearProgress';

type Props = {
  lineItems: LineItem[];
};

const TransactionReceipt: React.FC<Props> = ( { lineItems }) => {

  const generateReceipt = async (): Promise<SalesTransaction> => 
  // Fire off the request to the service
  await (await fetch(transactionEndpoint, {
    method: "POST",
    headers: new Headers({
        "Content-Type": "application/json",
        Accept: "application/json"
    }),
    body: JSON.stringify(lineItems)
  })).json();

  const { data, isLoading, error } = useQuery<SalesTransaction> (
    'transaction',
    generateReceipt
  );

  let count: number = 0;

  function LineItemSeparator() {
    count++;
    if (count != data?.receipt.lineItems.length) {
      return <Divider variant="middle"/>
    }
  }

  function LineItemFormatter(lineItem: LineItem) {
    if (lineItem.quantity > 1)
      return <p>
                {lineItem.product.name}: {lineItem.product.price} 
                ({lineItem.quantity} @ {lineItem.totalCostPerItem.toFixed(2)})
             </p>
    else
      return <p>{lineItem.product.name}: {lineItem.product.price}</p>

  }

  if (isLoading) return <LinearProgress />;
  if (error) return <div>Something went wrong ...</div>;

  return (
    <Wrapper>
      <div>
          <h2>Thank you for your purchase!</h2>
          {data?.receipt.lineItems.map(lineItem => (
            <div >
              {LineItemFormatter(lineItem)}
              {LineItemSeparator()}
            </div>
          ))}
          <hr/>
          <h4>Tax: ${data?.receipt.totalTax.toFixed(2)}</h4>
          <h4>Total: ${data?.receipt.totalCost.toFixed(2)}</h4>
        </div>
    </Wrapper>
    
  );
};

export default TransactionReceipt;
