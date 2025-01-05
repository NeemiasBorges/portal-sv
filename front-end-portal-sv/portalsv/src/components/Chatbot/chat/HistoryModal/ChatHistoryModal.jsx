import React from "react";
import Modal from "react-modal";
import { FaUser, FaRobot } from "react-icons/fa";
import { parseMessages, formatTimestamp } from "./utils";
import { HistoryMessage } from "./HistoryMessage";
import { modalStyles } from "./styles";

const ChatHistoryModal = ({ isOpen, onClose, chatData }) => {
  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onClose}
      contentLabel="Histórico da Conversa"
      style={modalStyles}
    >
      <div className="flex flex-col h-full">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-xl font-semibold">Histórico da Conversa</h2>
          <button
            onClick={onClose}
            className="bg-red-600 hover:bg-red-700 text-white px-4 py-2 rounded transition-colors"
          >
            Fechar
          </button>
        </div>

        <div className="flex-1 overflow-y-auto" style={{ height: "60vh" }}>
          <div className="space-y-4">
            {parseMessages(chatData?.resumoConversa || "[]").map(
              (message, index) => (
                <HistoryMessage key={index} message={message} />
              )
            )}
          </div>
        </div>
      </div>
    </Modal>
  );
};

export default ChatHistoryModal;
