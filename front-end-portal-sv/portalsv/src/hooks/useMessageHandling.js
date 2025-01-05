import { useState } from "react";
import { v4 as uuidv4 } from "uuid";

export const useMessageHandling = ({
  chatSession,
  setIsOpen,
  clearChatSession,
  setChatSession,
  setIsTyping,
}) => {
  const [inputMessage, setInputMessage] = useState("");

  const startNewChat = (email) => {
    // Generate UUID once when starting a new chat
    const sessionId = uuidv4();
    setChatSession({
      email,
      messages: [],
      isCompleted: false,
      satisfaction: null,
      sessionId, // Store the UUID in the chat session
    });
  };

  const sendMessage = async (text) => {
    if (!text.trim()) return;

    const newMessage = {
      text,
      sender: "user",
      timestamp: new Date().toISOString(),
    };

    setChatSession((prev) => ({
      ...prev,
      messages: [...prev.messages, newMessage],
    }));

    setIsTyping(true);

    try {
      const response = await fetch(
        `https://localhost:7071/api/v1/Chatbot?message=${encodeURIComponent(
          text
        )}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
          },
          body: JSON.stringify({ message: text }),
        }
      );

      const botResponse = await response.text();
      setIsTyping(false);

      setChatSession((prev) => ({
        ...prev,
        messages: [
          ...prev.messages,
          {
            text: botResponse,
            sender: "bot",
            timestamp: new Date().toISOString(),
          },
        ],
      }));
    } catch (error) {
      console.error(error);
      setIsTyping(false);
      setChatSession((prev) => ({
        ...prev,
        messages: [
          ...prev.messages,
          {
            text: "Desculpe, ocorreu um erro ao processar sua mensagem.",
            sender: "bot",
            timestamp: new Date().toISOString(),
          },
        ],
      }));
    }
  };

  const handleComplete = async (isComplete) => {
    if (isComplete) {
      try {
        await fetch("https://localhost:7071/api/v1/Chatbot/cria-historico", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            id: chatSession.sessionId, // Use the stored sessionId
            resumoConversa: JSON.stringify(chatSession.messages, null, 2),
            conversaConcluida: true,
            emailCliente: chatSession.email,
            categoria: 10,
            Satisfacao: "",
          }),
        });

        setChatSession((prev) => ({
          ...prev,
          isCompleted: true,
        }));
      } catch (error) {
        console.error("Erro ao completar o chat:", error);
      }
    }
  };

  const handleSatisfaction = async (rating) => {
    try {
      await fetch("https://localhost:7071/api/v1/Chatbot", {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          Id: chatSession.sessionId,
          Satisfacao: rating.toString(),
          resumoConversa: JSON.stringify(chatSession.messages, null, 2),
          conversaConcluida: true,
          emailCliente: chatSession.email,
        }),
      });

      setIsOpen(false);
      clearChatSession();
    } catch (error) {
      console.error("Erro ao enviar pesquisa de satisfação:", error);
    }
  };

  return {
    inputMessage,
    setInputMessage,
    sendMessage,
    handleComplete,
    handleSatisfaction,
    startNewChat,
  };
};
