import { format } from "date-fns";
import { ptBR } from "date-fns/locale";

const formatData = (data) => {
  if (!data) return "N/A";
  return format(new Date(data), "dd/MM/yyyy", { locale: ptBR });
};

export const columns = [
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
