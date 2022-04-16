import * as React from 'react';
// Types
import { Product } from '../App';
import { api, productEndpoint } from '../ApiClient';
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
import Select, { SelectChangeEvent } from '@mui/material/Select';
import DialogTitle from '@mui/material/DialogTitle';
import OutlinedInput from '@mui/material/OutlinedInput';
import AddBox from '@mui/icons-material/AddBox';
// Styles
import { StyledAddButton } from './../App.styles';

export default function FormDialog() {
    const [open, setOpen] = React.useState(false);
    const [product, setProduct] = React.useState({ } as Product);
    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setProduct({...product, [e.target.name] : e.currentTarget.value})
    };

    const selectHandleChange = (e: SelectChangeEvent<boolean>, child: React.ReactNode) => {
        if (e.target.value === "true" || e.target.value === "false") {
            setProduct({...product, [e.target.name] : e.target.value === 'true' ? true : false});
        }
        else
            setProduct({...product, [e.target.name] : e.target.value});
    };

    const handleAdd = () => {
        let data = api<void, Product>(productEndpoint, product);
        setOpen(false);
        window.location.reload();
    };
    
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
                        name="name"
                        required
                        value={product.name}
                        onChange={handleChange}
                    />
                    </FormControl>
                    <FormControl sx={{ mt: 2, minWidth: 120 }} fullWidth >
                    <TextField
                        autoFocus
                        id="productDescription"
                        label="Product Description"
                        name="description"
                        fullWidth
                        value={product.description}
                        onChange={handleChange}
                    />
                    </FormControl>
                    <FormControl sx={{ mt:2, mr:1, width: '30%' }} >
                    <InputLabel id="lblProductType">Type</InputLabel>
                    <Select
                        id="productType"
                        labelId="lblProductType"
                        label="Type"
                        name="type"
                        required
                        onChange={selectHandleChange}
                    >
                        <MenuItem value={1}>Other</MenuItem>
                        <MenuItem value={2}>Book</MenuItem>
                        <MenuItem value={3}>Food</MenuItem>
                        <MenuItem value={4}>Medical</MenuItem>
                    </Select>
                    </FormControl>
                    <FormControl sx={{ mt:2, mr:1, width: '30%' }} >
                    <InputLabel id="lblProductIsImported" defaultValue={0}>Status</InputLabel>
                    <Select
                        id="productIsImported"
                        labelId="lblProductIsImported"
                        label="Status"
                        name="isImported"
                        required
                        onChange={selectHandleChange}
                    >
                        <MenuItem value={'false'}>Local</MenuItem>
                        <MenuItem value={'true'}>Imported</MenuItem>
                    </Select>
                    </FormControl>
                    <FormControl sx={{ mt: 2, width: '37%' } }>
                        <InputLabel id="lblPrice">Price</InputLabel>
                        <OutlinedInput
                            id="filled-adornment-amount"
                            label="Price"
                            name="price"
                            onChange={handleChange}
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
    );
}