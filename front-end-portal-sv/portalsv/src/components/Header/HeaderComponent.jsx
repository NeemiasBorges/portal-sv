import { useState } from "react";
import { Container } from "./styles";
import { FaBars } from "react-icons/fa";
import Sidebar from "../Sidebar/SidebarComponent";

function Header() {
  const [sidebar, setSidebar] = useState(false);

  const showSidebar = () => setSidebar(!sidebar);

  return (
    <Container>
      <FaBars onClick={showSidebar} />
      <Sidebar active={sidebar} closeSidebar={() => setSidebar(false)} />
    </Container>
  );
}

export default Header;
