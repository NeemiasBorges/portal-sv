import { useState } from "react";
import TitleComponent from "./components/TitleComponent";
import DataTable from "react-data-table-component";
import Header from "./components/Header/HeaderComponent";
import { ChatWindow } from "./components/Chatbot/chat/ChatWindow/ChatWindow";
import { columns } from "./data/columnsData/clienteColumns";

function App() {
  const [clientes, setClientes] = useState([
    fetch(
      "https://localhost:7071/api/v1/cliente?numero_pagina=0&quantidade_p_pagina=10"
    )
      .then((response) => response.json())
      .then((data) => setClientes(data)),
  ]);

  return (
    <div>
      <Header />
      <TitleComponent>Listagem de Clientes</TitleComponent>
      <DataTable
        fixedHeader
        title="Clientes"
        pagination
        selectableRows
        columns={columns}
        data={clientes}
      />
      <ChatWindow />
    </div>
  );
}

export default App;
