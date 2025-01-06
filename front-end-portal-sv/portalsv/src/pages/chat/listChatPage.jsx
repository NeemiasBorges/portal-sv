import { useState, useEffect } from "react";
import Header from "../../components/Header/HeaderComponent";
import DataTable from "react-data-table-component";
import { chatbotColumns } from "../../data/columnsData/chatbotColumns";
import ChatHistoryModal from "../../components/Chatbot/chat/HistoryModal/ChatHistoryModal";

function ListChat() {
  const [chats, setChats] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [modalData, setModalData] = useState(null);

  useEffect(() => {
    fetch("https://localhost:7071/api/v1/Chatbot")
      .then((response) => response.json())
      .then((data) => setChats(data))
      .catch((error) => console.error("Erro ao buscar dados:", error));
  }, []);

  const columns = chatbotColumns(setModalData, setIsModalOpen);

  return (
    <div>
      <Header />
      <div className="container shadow-lg max-w-5xl mx-auto p-5 m-5">
        <DataTable
          title="Conversas"
          pagination
          selectableRows
          columns={columns}
          data={chats}
        />
        <ChatHistoryModal
          className="p-10"
          isOpen={isModalOpen}
          onClose={() => setIsModalOpen(false)}
          chatData={modalData}
        />
      </div>
    </div>
  );
}

export default ListChat;
