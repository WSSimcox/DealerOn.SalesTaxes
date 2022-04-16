import styled from 'styled-components';
import IconButton from '@material-ui/core/IconButton';

export const Wrapper = styled.div`
  display: flex;
  justify-content: space-between;
  flex-direction: column;
  height: 100%;
  width: 100%;
  border: 1px solid #122e5d;
  border-radius: 20px;

  img {
    height: 256px;
    padding-top: 20px;
    object-fit: contain;
    border-radius: 20px 20px 0 0;
  }

  div {
    font-family: Arial, Helvetica, sans-serif;
    padding: 1rem;
    height: 100%;
  }

  #deleteContainer {
    text-align: right;
  }
`;

export const StyledDeleteButton = styled(IconButton)`
`;
