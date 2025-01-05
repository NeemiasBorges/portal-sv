import { createRoot } from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { BrowserRouter, Routes, Route } from "react-router";
import ListChat from "./pages/chat/listChatPage.jsx";
import Modal from "react-modal";

Modal.setAppElement("#root");
createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="/chatbot" element={<ListChat />} />
      {/* <Route path="/configuracoes" element={<ListChat />} /> 
       <Link to="/configuracoes">
      <Link to="/logout"> */}
    </Routes>
  </BrowserRouter>
);
