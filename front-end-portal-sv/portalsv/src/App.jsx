import { useState } from "react";
import TitleComponent from "./components/TitleComponent";
import DataTable from "react-data-table-component";
import Header from "./components/Header/HeaderComponent";
import { ChatWindow } from "./components/Chatbot/chat/ChatWindow";
import { format } from "date-fns";
import { ptBR } from "date-fns/locale";

function App() {
  const [clientes, setClientes] = useState([
    fetch(
      "https://localhost:7071/api/v1/cliente?numero_pagina=0&quantidade_p_pagina=10"
    )
      .then((response) => response.json())
      .then((data) => setClientes(data)),
  ]);

  const formatData = (data) => {
    if (!data) return "N/A";
    return format(new Date(data), "dd/MM/yyyy", { locale: ptBR });
  };

  const columns = [
    {
      name: "Nome",
      selector: (row) => row.nome,
      sortable: true,
    },
    {
      name: "Email",
      selector: (row) => row.email,
      sortable: true,
    },
    {
      name: "CPF",
      selector: (row) => row.cpf || "N/A",
      sortable: true,
    },
    {
      name: "Telefone",
      selector: (row) => row.telefone || "N/A",
      sortable: true,
    },
    {
      name: "Sexo",
      selector: (row) => row.sexo || "N/A",
      sortable: true,
    },
    {
      name: "CEP",
      selector: (row) => row.cep || "N/A",
      sortable: true,
    },
    {
      name: "Data de Criação",
      selector: (row) => formatData(row.dataCriacao),
      sortable: true,
    },
  ];

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
