import React, { useState, useEffect } from "react";
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
      <DataTable
        title="Conversas"
        pagination
        selectableRows
        columns={columns}
        data={chats}
      />
      <ChatHistoryModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        chatData={modalData}
      />
    </div>
  );
}

export default ListChat;
