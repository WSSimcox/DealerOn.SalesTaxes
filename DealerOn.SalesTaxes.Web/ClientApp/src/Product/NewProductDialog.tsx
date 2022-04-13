import * as React from 'react';
// Types
import { Product } from '../App';
// Material
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import InputAdornment from '@mui/material/InputAdornment';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import DialogTitle from '@mui/material/DialogTitle';
import OutlinedInput from '@mui/material/OutlinedInput';
import AddBox from '@mui/icons-material/AddBox';
// Styles
import { StyledAddButton } from './../App.styles';

export default function FormDialog() {
    const [open, setOpen] = React.useState(false);
    const [product, setProduct] = React.useState({} as Product);
    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleAdd = () => {
        product.price = 12.99;
        // Fire off the request to the service
        fetch('https://localhost:44301/api/v1/product', {
            method: "POST",
            headers: new Headers({
                "Content-Type": "application/json",
                Accept: "application/json"
            }),
            body: JSON.stringify(product)
        });
        // Close the dialog
        setOpen(false);
    };

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const newValue = e.currentTarget.value;
        //setRegister({ ...register, name: e.currentTarget.value })
    }
    
    return (
        <div>
        <StyledAddButton onClick={() => handleClickOpen()}>
          <AddBox />
        </StyledAddButton>
            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Add New Product</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        Please fill out all the required fields to add new product to the system.
                    </DialogContentText>
                    <br/>
                    <FormControl sx={{ mt:0 }} fullWidth >
                    <TextField
                        autoFocus
                        id="productName"
                        label="Product Name"
                        required
                    />
                    </FormControl>
                    <FormControl sx={{ mt: 2, minWidth: 120 } } fullWidth >
                    <TextField
                        autoFocus
                        id="productDescription"
                        label="Product Description"
                        fullWidth
                    />
                    </FormControl>
                    <FormControl sx={{ mt:2, mr:1,width: '30%' }} >
                    <InputLabel id="lblProductType">Type</InputLabel>
                    <Select
                        id="productType"
                        labelId="lblProductType"
                        label="Type"
                        required
                    >
                        <MenuItem value={1}>Other</MenuItem>
                        <MenuItem value={2}>Book</MenuItem>
                        <MenuItem value={3}>Food</MenuItem>
                        <MenuItem value={4}>Medical</MenuItem>
                    </Select>
                    </FormControl>
                    <FormControl sx={{ mt:2, mr:1, width: '30%' }} >
                    <InputLabel id="lblProductType">Status</InputLabel>
                    <Select
                        id="productIsImported"
                        labelId="lblProductIsImported"
                        label="Status"
                        required
                    >
                        <MenuItem value={1}>Imported</MenuItem>
                        <MenuItem value={2}>Local</MenuItem>
                    </Select>
                    </FormControl>
                    <FormControl sx={{ mt: 2, width: '37%' } }>
                        <InputLabel id="lblPrice">Price</InputLabel>
                        <OutlinedInput
                            id="filled-adornment-amount"
                            label="Price"
                            inputProps={{ inputMode: 'numeric', pattern: '([0-9])'}}
                            startAdornment={<InputAdornment position="start">$</InputAdornment>}
                        />
                    </FormControl>
                </DialogContent>
                <DialogActions>
                    <Button variant="outlined" onClick={handleClose}>Cancel</Button>
                    <Button variant="contained" onClick={handleAdd}>Add</Button>
                </DialogActions>
            </Dialog>
        </div>
        // </Box>
    );
}