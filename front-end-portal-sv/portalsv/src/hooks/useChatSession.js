import { useState, useEffect } from "react";
import { useLocalStorage } from "../hooks/useLocalStorage";

export const useChatSession = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [chatSession, setChatSession] = useLocalStorage("chatSession", null);
  const [isTyping, setIsTyping] = useState(false);
  const [idUserAtual, setIdUserAtual] = useLocalStorage("chatSessionId", null);

  const clearChatSession = () => {
    setChatSession(null);
    setIdUserAtual(null);
    localStorage.removeItem("chatSession");
    localStorage.removeItem("chatSessionId");
  };

  useEffect(() => {
    window.addEventListener("beforeunload", clearChatSession);
    return () => window.removeEventListener("beforeunload", clearChatSession);
  }, []);

  useEffect(() => {
    if (chatSession && chatSession.messages.length === 0) {
      setChatSession((prev) => ({
        ...prev,
        messages: [
          {
            text: "Olá, como posso ajudar com o seu seguro de viagem hoje?",
            sender: "bot",
            timestamp: new Date(),
          },
        ],
      }));
    }
  }, [chatSession]);

  return {
    isOpen,
    setIsOpen,
    chatSession,
    setChatSession,
    isTyping,
    setIsTyping,
    idUserAtual,
    setIdUserAtual,
    clearChatSession,
  };
};
