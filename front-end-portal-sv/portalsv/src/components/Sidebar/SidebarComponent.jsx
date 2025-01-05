import PropTypes from "prop-types";
import { FaTimes, FaRegSun, FaRobot } from "react-icons/fa";
import SidebarItem from "../SidebarItem/SidebarItemComponent";
import { Container, Content } from "./styles";
import { Link } from "react-router";

const Sidebar = ({ active, closeSidebar }) => {
  return (
    <Container sidebar={active}>
      <FaTimes onClick={closeSidebar} />
      <Content>
        <Link to="/chatbot">
          <SidebarItem Icon={FaRobot} Text="Chatbot" />
        </Link>
        <Link to="/configuracoes">
          <SidebarItem Icon={FaRegSun} Text="Configurações" />
        </Link>
      </Content>
    </Container>
  );
};

Sidebar.propTypes = {
  active: PropTypes.bool.isRequired,
  closeSidebar: PropTypes.func.isRequired,
};

export default Sidebar;
