import { FaUser, FaRobot } from "react-icons/fa";

export const Message = ({ message }) => (
  <div
    className={`flex ${
      message.sender === "user" ? "justify-end" : "justify-start"
    }`}
  >
    <div
      className={`max-w-[80%] rounded-lg p-3 ${
        message.sender === "user"
          ? "bg-blue-600 text-white"
          : "bg-gray-100 text-gray-800"
      }`}
    >
      <div className="flex items-center gap-2 mb-1">
        {message.sender === "user" ? (
          <FaUser size={12} />
        ) : (
          <FaRobot size={12} />
        )}
        <span className="text-xs">
          {message.timestamp.toLocaleTimeString()}
        </span>
      </div>
      <p className="text-sm">{message.text.replace(/"/g, "")}</p>
    </div>
  </div>
);
