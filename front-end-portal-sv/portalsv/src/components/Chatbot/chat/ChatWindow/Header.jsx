import React from "react";

export const Header = ({ onClose }) => (
  <div className="bg-blue-600 p-4 rounded-t-lg flex items-center">
    <h3 className="text-white font-medium">Assistente Virtual</h3>
    <button onClick={onClose} className="ml-auto text-white">
      ×
    </button>
  </div>
);
