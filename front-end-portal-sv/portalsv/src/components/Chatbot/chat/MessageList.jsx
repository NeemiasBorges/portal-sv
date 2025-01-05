import { useEffect, useRef } from "react";
import { Message } from "./Message";
import { TypingIndicator } from "./TypingIndicator";

export const MessageList = ({ messages, isTyping }) => {
  const messagesEndRef = useRef(null);

  useEffect(() => {
    messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [messages]);

  return (
    <div className="h-96 overflow-y-auto p-4 flex flex-col gap-4">
      {messages.map((message) => (
        <Message key={message.id} message={message} />
      ))}
      {isTyping && <TypingIndicator />}
      <div ref={messagesEndRef} />
    </div>
  );
};
