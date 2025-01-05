import { useState, useEffect } from "react";
import { useLocalStorage } from "../../../hooks/useLocalStorage";
import { Bolha } from "../../Chatbot/BolhaComponent";
import { EmailInput } from "./EmailInput";
import { MessageList } from "./MessageList";
import { PesquisaSatisfacao } from "./pesquisaSatisfacao";
import { FaPaperPlane } from "react-icons/fa";
import { v4 as uuidv4 } from "uuid";

export const ChatWindow = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [chatSession, setChatSession] = useLocalStorage("chatSession", null);
  const [isTyping, setIsTyping] = useState(false);
  const [inputMessage, setInputMessage] = useState("");
  const [idUserAtual, setIdUserAtual] = useLocalStorage("chatSessionId", null);

  // Inicializa o UUID apenas quando uma nova sessão de chat é iniciada
  const initializeUUID = () => {
    if (!idUserAtual) {
      const newId = uuidv4();
      setIdUserAtual(newId);
      return newId;
    }
    return idUserAtual;
  };

  // Limpa todos os dados da sessão
  const clearChatSession = () => {
    setChatSession(null);
    setIdUserAtual(null);
    localStorage.removeItem("chatSession");
    localStorage.removeItem("chatSessionId");
  };

  useEffect(() => {
    // Limpa o armazenamento local ao sair da página
    window.addEventListener("beforeunload", clearChatSession);

    return () => {
      window.removeEventListener("beforeunload", clearChatSession);
    };
  }, []);

  useEffect(() => {
    if (chatSession && chatSession.messages.length === 0) {
      // Adiciona mensagem inicial do bot
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

  const startNewChat = (email) => {
    const newId = initializeUUID();
    setChatSession({
      email,
      messages: [],
      isCompleted: false,
      satisfaction: null,
      sessionId: newId,
    });
  };

  const sendMessage = async (text) => {
    if (!text.trim()) return;

    const newMessage = {
      text,
      sender: "user",
      timestamp: new Date(),
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
            timestamp: new Date(),
          },
        ],
      }));
    } catch (error) {
      console.log(error);
      setIsTyping(false);
      setChatSession((prev) => ({
        ...prev,
        messages: [
          ...prev.messages,
          {
            text: "Desculpe, ocorreu um erro ao processar sua mensagem.",
            sender: "bot",
            timestamp: new Date(),
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
            id: idUserAtual,
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
          chatId: idUserAtual,
          Satisfacao: rating.toString(),
          resumoConversa: JSON.stringify(chatSession.messages, null, 2),
          conversaConcluida: true,
          emailCliente: chatSession.email,
        }),
      });

      // Fecha o chat e limpa todos os dados da sessão
      setIsOpen(false);
      clearChatSession();
    } catch (error) {
      console.error("Erro ao enviar pesquisa de satisfação:", error);
    }
  };

  return (
    <div className="fixed bottom-4 right-4 z-50">
      <Bolha
        onClick={() => setIsOpen(!isOpen)}
        isActive={chatSession?.messages.length > 0}
      />

      {isOpen && (
        <div className="absolute bottom-20 right-0 w-96 bg-white rounded-lg shadow-xl">
          <div className="bg-blue-600 p-4 rounded-t-lg flex items-center">
            <h3 className="text-white font-medium">Assistente Virtual</h3>
            <button
              onClick={() => setIsOpen(false)}
              className="ml-auto text-white"
            >
              ×
            </button>
          </div>

          {!chatSession?.email ? (
            <EmailInput onSubmit={startNewChat} />
          ) : (
            <>
              <MessageList
                messages={chatSession.messages}
                isTyping={isTyping}
              />

              {!chatSession.isCompleted && chatSession.messages.length > 0 && (
                <div className="p-4 border-t">
                  <p>A solicitação foi concluída?</p>
                  <div className="flex gap-2">
                    <button
                      onClick={() => handleComplete(true)}
                      className="bg-green-500 text-white p-2 rounded"
                    >
                      Sim
                    </button>
                    <button
                      onClick={() => handleComplete(false)}
                      className="bg-blue-500 text-white p-2 rounded"
                    >
                      Não
                    </button>
                  </div>
                </div>
              )}

              {chatSession.isCompleted && !chatSession.satisfaction && (
                <PesquisaSatisfacao onSelect={handleSatisfaction} />
              )}

              {!chatSession.isCompleted && (
                <form
                  onSubmit={(e) => {
                    e.preventDefault();
                    sendMessage(inputMessage);
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
                    <button
                      type="submit"
                      className="bg-blue-600 text-white p-2 rounded"
                    >
                      <FaPaperPlane />
                    </button>
                  </div>
                </form>
              )}
            </>
          )}
        </div>
      )}
    </div>
  );
};
