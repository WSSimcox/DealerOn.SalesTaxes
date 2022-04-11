import { useState } from 'react';
import { useQuery } from 'react-query';
// Components
import Navbar from './Navbar/Navbar';
import Item from './Product/Product';
import Cart from './Cart/Cart';
import Drawer from '@material-ui/core/Drawer';
import LinearProgress from '@material-ui/core/LinearProgress';
import Grid from '@material-ui/core/Grid';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import AddBoxIcon from '@material-ui/icons/AddBox';
import Badge from '@material-ui/core/Badge';
// Styles
import { Wrapper, StyledCartButton, StyledAddButton } from './App.styles';
import { AddBox } from '@material-ui/icons';
// Types
export type SalesTransactionType = {
  id: string;
  transactionDate: Date;
  lineItems: LineItemType[];
}

export type ReceiptType = {
  totalTax: number;
  totalCost: number;
}

export type LineItemType = {
  product: ProductType;
  quantity: number;
}

export type ProductType = {
  id: string;
  name: string;
  type: ProductEnumType;
  description: string;
  price: number;
  amount: number;
};

export enum ProductEnumType {
  Other = 1,
  Book = 2,
  Food = 3,
  Medical = 4
};

const getProducts = async (): Promise<ProductType[]> =>
  await (await fetch('https://localhost:44301/api/v1/product')).json();

const App = () => {
  const [cartOpen, setCartOpen] = useState(false);
  const [cartProducts, setCartProducts] = useState([] as ProductType[]);
  const { data, isLoading, error } = useQuery<ProductType[]>(
    'products',
    getProducts
  );

  const getTotalProducts = (items: ProductType[]) =>
    items.reduce((ack: number, item) => ack + item.amount, 0);

  const handleAddToCatelog = (clickedItem: ProductType) => {
    setCartProducts(prev => {
      // 1. Is the item already added in the cart?
      const isItemInCart = prev.find(item => item.id === clickedItem.id);

      if (isItemInCart) {
        return prev.map(item =>
          item.id === clickedItem.id
            ? { ...item, amount: item.amount + 1 }
            : item
        );
      }
      // First time the item is added
      return [...prev, { ...clickedItem, amount: 1 }];
    });
  };

  const handleAddToCart = (clickedItem: ProductType) => {
    setCartProducts(prev => {
      // 1. Is the item already added in the cart?
      const isItemInCart = prev.find(item => item.id === clickedItem.id);

      if (isItemInCart) {
        return prev.map(item =>
          item.id === clickedItem.id
            ? { ...item, amount: item.amount + 1 }
            : item
        );
      }
      // First time the item is added
      return [...prev, { ...clickedItem, amount: 1 }];
    });
  };

  const handleRemoveFromCart = (id: string) => {
    setCartProducts(prev =>
      prev.reduce((ack, item) => {
        if (item.id === id) {
          if (item.amount === 1) return ack;
          return [...ack, { ...item, amount: item.amount - 1 }];
        } else {
          return [...ack, item];
        }
      }, [] as ProductType[])
    );
  };

  if (isLoading) return <LinearProgress />;
  if (error) return <div>Something went wrong ...</div>;

  return (
    <Wrapper>
      <Navbar></Navbar>
      <Drawer anchor='right' open={cartOpen} onClose={() => setCartOpen(false)}>
        <Cart
          products={cartProducts}
          addToCart={handleAddToCart}
          removeFromCart={handleRemoveFromCart}
        />
      </Drawer>
      <StyledAddButton onClick={() => setCartOpen(true)}>
          <AddBox />
      </StyledAddButton>
      <StyledCartButton onClick={() => setCartOpen(true)}>
        <Badge badgeContent={getTotalProducts(cartProducts)} color='error'>
          <ShoppingCartIcon />
        </Badge>
      </StyledCartButton>
      <Grid container spacing={3}>
        {data?.map(item => (
          <Grid item key={item.id} xs={12} sm={4}>
            <Item product={item} handleAddToCart={handleAddToCart} />
          </Grid>
        ))}
      </Grid>
    </Wrapper>
  );
};

export default App;
