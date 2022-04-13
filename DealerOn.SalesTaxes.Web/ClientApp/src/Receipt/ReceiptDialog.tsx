import * as React from 'react';
// Material
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormHelperText from '@mui/material/FormHelperText';
import InputAdornment from '@mui/material/InputAdornment';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import Box from '@mui/material/Box';
import DialogTitle from '@mui/material/DialogTitle';
import FilledInput from '@mui/material/FilledInput';
import OutlinedInput from '@mui/material/OutlinedInput';
import AddBox from '@mui/icons-material/AddBox';
import Checkbox from '@mui/material/Checkbox';
// Styles
import { Wrapper, StyledCartButton, StyledAddButton } from './../App.styles';
import { FormControlLabel, FormGroup } from '@material-ui/core';

export default function FormDialog() {
    const [open, setOpen] = React.useState(false);
    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    return (
        <Box sx={{ display: 'flex', flexWrap: 'wrap' }}>
        <div>
        <StyledAddButton onClick={() => handleClickOpen()}>
          <AddBox />
        </StyledAddButton>
            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Thank You!</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        Below is your transaction details.
                    </DialogContentText>
                    <br/>
                    <FormControl sx={{ m: 1, minWidth: 120 }} >
                    <TextField
                        autoFocus
                        id="productName"
                        label="Product Name"
                        required
                        fullWidth
                    />
                    </FormControl>
                    <FormControl sx={{ m: 1, minWidth: 120 }} >
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
                    <FormControl sx={{ m: 1, minWidth: 80 }}>
                        <InputLabel id="lblPrice">Price</InputLabel>
                        <OutlinedInput
                            id="filled-adornment-amount"
                            label="es"
                            inputProps={{ inputMode: 'numeric', pattern: '([0-9])'}}
                            startAdornment={<InputAdornment position="start">$</InputAdornment>}
                        />
                    </FormControl>
                    <FormControl>
                        <FormControlLabel control={<Checkbox />} label="Imported" />
                    </FormControl>
                    <FormControl sx={{ m: 1, minWidth: 120 }} >
                    <TextField
                        autoFocus
                        id="productDescription"
                        label="Product Description"
                        fullWidth
                    />
                    </FormControl>
                </DialogContent>
                <DialogActions>
                    <Button variant="outlined" onClick={handleClose}>Cancel</Button>
                    <Button variant="contained" onClick={handleClose}>Add</Button>
                </DialogActions>
            </Dialog>
        </div>
        </Box>
    );
}