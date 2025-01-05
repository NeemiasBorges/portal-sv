import styled from "styled-components";

export const Container = styled.div`
  position: fixed;
  top: 0;
  left: ${({ sidebar }) =>
    sidebar ? "0" : "-100%"}; /* Move para fora da tela */
  width: 250px;
  height: 100%;
  background-color: #333;
  color: white;
  transition: left 0.3s ease-in-out; /* Transição suave */
  z-index: 1000;
  display: flex;
  flex-direction: column;
`;

export const Content = styled.div`
  margin-top: 50px;
  padding: 20px;
  ul {
    list-style: none;
    padding: 0;
    li {
      margin: 10px 0;
    }
  }
`;
