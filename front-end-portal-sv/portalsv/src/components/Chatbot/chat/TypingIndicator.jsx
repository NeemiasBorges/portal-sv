import { FaRobot } from "react-icons/fa";

export const TypingIndicator = () => (
  <div className="flex items-center gap-2 text-gray-500">
    <FaRobot size={16} />
    <div className="flex gap-1">
      <div className="w-2 h-2 bg-gray-400 rounded-full animate-bounce" />
      <div
        className="w-2 h-2 bg-gray-400 rounded-full animate-bounce"
        style={{ animationDelay: "0.2s" }}
      />
      <div
        className="w-2 h-2 bg-gray-400 rounded-full animate-bounce"
        style={{ animationDelay: "0.4s" }}
      />
    </div>
  </div>
);
