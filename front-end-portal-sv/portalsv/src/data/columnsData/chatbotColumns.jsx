import { format } from "date-fns";
import { ptBR } from "date-fns/locale";
import { FaEye } from "react-icons/fa";

const categoryMap = {
  0: "Cobertura do Seguro",
  1: "Preços e Cotações",
  2: "Contratação e Renovação",
  3: "Assistência Durante a Viagem",
  4: "Reembolsos e Reivindicações",
  5: "Alterações na Apólice",
  6: "Dúvidas Sobre Destinos",
  7: "Promoções e Descontos",
  8: "Problemas Técnicos",
  9: "Esclarecimento de Termos",
  10: "Outros",
};

const emojis = ["😢", "😕", "😐", "🙂", "😄"];

let formatDataChat = (data) => {
  if (!data) return "N/A";
  return format(new Date(data), "dd/MM/yyyy", { locale: ptBR });
};

export const chatbotColumns = (setModalData, setIsModalOpen) => [
  {
    name: "Data Mensagem",
    selector: (row) => formatDataChat(row.dataMensagem),
    sortable: true,
  },
  {
    name: "Conversa Concluída",
    selector: (row) => (row.conversaConcluida == true ? "Sim" : "Não"),
    sortable: false,
  },
  {
    name: "Email Cliente",
    selector: (row) => row.emailCliente,
    sortable: true,
  },
  {
    name: "Categoria",
    selector: (row) => categoryMap[row.categoria] || "Categoria Não Definida",
    sortable: true,
  },
  {
    name: "Satisfação",
    selector: (row) => {
      const rating = parseInt(row.satisfacao, 10);
      return rating >= 1 && rating <= 5 ? emojis[rating - 1] : "N/A";
    },
    sortable: true,
  },
  {
    name: "Histórico da Conversa",
    cell: (row) => (
      <button
        onClick={() => {
          setModalData(row);
          setIsModalOpen(true);
        }}
        className="bg-blue-600 text-white p-2 rounded"
      >
        <FaEye />
      </button>
    ),
    sortable: false,
  },
];
