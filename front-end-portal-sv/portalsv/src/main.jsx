import { createRoot } from "react-dom/client";
import { BrowserRouter, Routes, Route, Navigate } from "react-router";
import Modal from "react-modal";
import App from "./App.jsx";
import "./index.css";
import ListChat from "./pages/chat/listChatPage.jsx";
import Login from "./pages/login/loginPage.jsx";

const ProtectedRoute = ({ children }) => {
  const isAuthenticated = !!localStorage.getItem("jwt");

  if (!isAuthenticated) {
    return <Navigate to="/" replace />;
  }

  return children;
};

Modal.setAppElement("#root");

createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Routes>
      <Route
        path="/"
        element={
          localStorage.getItem("jwt") ? (
            <Navigate to="/clientes" replace />
          ) : (
            <Login />
          )
        }
      />
      <Route
        path="/chatbot"
        element={
          <ProtectedRoute>
            <ListChat />
          </ProtectedRoute>
        }
      />
      <Route
        path="/configuracoes"
        element={
          <ProtectedRoute>
            <ListChat />
          </ProtectedRoute>
        }
      />
      <Route
        path="/clientes"
        element={
          <ProtectedRoute>
            <App />
          </ProtectedRoute>
        }
      />
    </Routes>
  </BrowserRouter>
);
