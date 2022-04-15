import styled from 'styled-components';

export const Wrapper = styled.div`
  display: flex;
  justify-content: space-between;
  font-family: Arial, Helvetica, sans-serif;
  padding-bottom: 20px;

  div {
    flex: 1;
  }

  .information,
  .buttons {
    display: flex;
    justify-content: space-between;
  }

  hr {
    border-bottom: 1px solid lightblue;
  }

  p {
    font-family: Helvetica
  }

  .left {
    float: left;
    text-align: left;
  } 

  .right {
      float: right;
      text-align: right;
  }
`;