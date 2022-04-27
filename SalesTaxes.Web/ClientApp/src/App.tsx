import { useState } from 'react';
import { useQuery } from 'react-query';
// Components
import Navbar from './Navbar/Navbar';
import ProductCard from './Product/Product';
import Cart from './Cart/Cart';
import NewProductDialog from './Product/NewProductDialog';
// Material
import Drawer from '@mui/material//Drawer';
import Grid from '@mui/material/Grid';
import Badge from '@mui/material/Badge';
import LinearProgress from '@material-ui/core/LinearProgress';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
// Styles
import { Wrapper, StyledCartButton } from './App.styles';
// Types
import { productEndpoint } from './ApiClient';

export type SalesTransaction = {
  id: string;
  transactionDate: Date;
  lineItems: LineItem[];
  receipt: Receipt;
}

export type Receipt = {
  lineItems: LineItem[];
  totalTax: number;
  totalCost: number;
}

export type LineItem = {
  product: Product;
  productId: string;
  productName: string;
  totalCostPerItem: number;
  quantity: number;
}

export type Product = {
  id: string;
  name: string;
  type: ProductType;
  description: string;
  price: number;
  isImported: boolean;
  amount: number;
};

export enum ProductType {
  Other = 1,
  Book = 2,
  Food = 3,
  Medical = 4
};

const getProducts = async (): Promise<Product[]> =>
  await (await fetch(productEndpoint)).json();

const App = () => {
  const [cartOpen, setCartOpen] = useState(false);
  const [cartProducts, setCartProducts] = useState([] as Product[]);
  const { data, isLoading, error } = useQuery<Product[]>(
    'products',
    getProducts
  );

  const getTotalProducts = (items: Product[]) =>
    items.reduce((ack: number, item) => ack + item.amount, 0);

  const handleAddToCart = (clickedItem: Product) => {
    setCartProducts(prev => {
      const isItemInCart = prev.find(item => item.id === clickedItem.id);

      if (isItemInCart) {
        return prev.map(item =>
          item.id === clickedItem.id
            ? { ...item, amount: item.amount + 1 }
            : item
        );
      }
      return [...prev, { ...clickedItem, amount: 1 }];
    });
  };

  const handleDeleteProduct = (clickedItem: Product) => {
    fetch(productEndpoint + clickedItem.id, { method: 'DELETE'});
    //Todo: find how to use state
    window.location.reload();
    return (null);
  };

  const handleRemoveFromCart = (id: string, allItems: boolean = false) => {
    setCartProducts(prev =>
      prev.reduce((ack, item) => {
        if (item.id === id) {
          if (item.amount === 1 || allItems) return ack;
          return [...ack, { ...item, amount: item.amount - 1 }];
        } else {
          return [...ack, item];
        }
      }, [] as Product[])
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
      <NewProductDialog/>
      {/* Two options */}
      <StyledCartButton onClick={() => setCartOpen(true)}>
        <Badge badgeContent={getTotalProducts(cartProducts)} color='error'>
          <ShoppingCartIcon />
        </Badge>
      </StyledCartButton>
      <Grid container spacing={6}>
        {data?.map(item => (
          <Grid item key={item.id} xs={6} md={2}>
            <ProductCard product={item} handleAddToCart={handleAddToCart} handleDeleteProduct={handleDeleteProduct} />
          </Grid>
        ))}
      </Grid>
    </Wrapper>
  );
};

export default App;
