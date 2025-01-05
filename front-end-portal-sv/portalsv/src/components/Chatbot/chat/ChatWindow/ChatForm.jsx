import React from "react";
import { FaPaperPlane } from "react-icons/fa";

export const ChatForm = ({ inputMessage, setInputMessage, onSubmit }) => (
  <form
    onSubmit={(e) => {
      e.preventDefault();
      onSubmit(inputMessage);
      setInputMessage("");
    }}
    className="p-4 border-t"
  >
    <div className="flex gap-2">
      <input
        type="text"
        value={inputMessage}
        onChange={(e) => setInputMessage(e.target.value)}
        placeholder="Digite sua mensagem..."
        className="flex-1 p-2 border rounded"
      />
      <button type="submit" className="bg-blue-600 text-white p-2 rounded">
        <FaPaperPlane />
      </button>
    </div>
  </form>
);
