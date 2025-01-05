import { ChatWindow } from "./components/Chatbot/chat/ChatWindow/ChatWindow";
import ListClientePage from "./pages/cliente/listClientePage";
import "./App.css";

function App() {
  const baseUrl = import.meta.env.VITE_REACT_APP_BASE_URL;
  const pageSize = import.meta.env.VITE_REACT_APP_PAGE_SIZE;
  const firstPage = import.meta.env.VITE_REACT_APP_FIRST_PAGE;

  return (
    <div>
      <ListClientePage />
      <ChatWindow />
    </div>
  );
}
export default App;
