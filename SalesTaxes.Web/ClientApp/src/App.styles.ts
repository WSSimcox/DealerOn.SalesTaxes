import styled from 'styled-components';
import IconButton from '@material-ui/core/IconButton';

export const Wrapper = styled.div`
  padding-top: 50px;
  margin: 40px;

  .hidden {
    display: none;
  }
`;

export const StyledCartButton = styled(IconButton)`
  position: fixed;
  z-index: 100;
  right: 10px;
  top: 10px;
`;

export const StyledAddButton = styled(IconButton)`
  position: fixed;
  z-index: 100;
  right: 60px;
  top: 10px;
`;