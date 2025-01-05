import { createRoot } from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { BrowserRouter, Routes, Route } from "react-router";
import Modal from "react-modal";
import ListChat from "./pages/chat/listChatPage.jsx";
// import Login from "";
// import Logout from "";

Modal.setAppElement("#root");
createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="/chatbot" element={<ListChat />} />
      <Route path="/configuracoes" element={<ListChat />} />
      {/* <Route to="/login" element={<Login />} />
      <Route to="/logout" element={<Logout />} />  */}
    </Routes>
  </BrowserRouter>
);
