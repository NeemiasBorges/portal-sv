import { useState } from "react";

export const EmailInput = ({ onSubmit }) => {
  const [email, setEmail] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    if (email.includes("@")) {
      onSubmit(email);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="p-4">
      <input
        type="email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        placeholder="Digite seu email para começar..."
        className="w-full p-2 border rounded"
        required
      />
      <button type="submit" className="mt-2 bg-blue-600 text-white p-2 rounded">
        Começar Chat
      </button>
    </form>
  );
};
