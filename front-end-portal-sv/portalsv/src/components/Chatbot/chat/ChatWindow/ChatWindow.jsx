import React from "react";
import { Bolha } from "../../BolhaComponent";
import { EmailInput } from "../EmailInput";
import { MessageList } from "../MessageList";
import { PesquisaSatisfacao } from "../pesquisaSatisfacao";
import { ChatForm } from "./ChatForm";
import { CompletionButtons } from "./CompletionButtons";
import { useChatSession } from "../../../../hooks/useChatSession";
import { useMessageHandling } from "../../../../hooks/useMessageHandling";
import { Header } from "./Header";

export const ChatWindow = () => {
  const { isOpen, setIsOpen, chatSession, isTyping, clearChatSession } =
    useChatSession();

  const {
    inputMessage,
    setInputMessage,
    sendMessage,
    handleComplete,
    handleSatisfaction,
    startNewChat,
  } = useMessageHandling({ chatSession, setIsOpen, clearChatSession });

  return (
    <div className="fixed bottom-4 right-4 z-50">
      <Bolha
        onClick={() => setIsOpen(!isOpen)}
        isActive={chatSession?.messages.length > 0}
      />

      {isOpen && (
        <div className="absolute bottom-20 right-0 w-96 bg-white rounded-lg shadow-xl">
          <Header onClose={() => setIsOpen(false)} />

          {!chatSession?.email ? (
            <EmailInput onSubmit={startNewChat} />
          ) : (
            <>
              <MessageList
                messages={chatSession.messages}
                isTyping={isTyping}
              />

              <CompletionButtons
                chatSession={chatSession}
                onComplete={handleComplete}
                onSatisfaction={handleSatisfaction}
              />

              {!chatSession.isCompleted && (
                <ChatForm
                  inputMessage={inputMessage}
                  setInputMessage={setInputMessage}
                  onSubmit={sendMessage}
                />
              )}
            </>
          )}
        </div>
      )}
    </div>
  );
};
