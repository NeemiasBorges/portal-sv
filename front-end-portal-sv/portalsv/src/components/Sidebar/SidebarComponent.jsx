import PropTypes from "prop-types";
import { FaKey, FaTimes, FaUser, FaRobot, FaDoorOpen } from "react-icons/fa";
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

        <Link to="/">
          <SidebarItem Icon={FaUser} Text="Clientes" />
        </Link>

        <Link to="/login">
          <SidebarItem Icon={FaKey} Text="Login" />
        </Link>

        <Link to="/logout">
          <SidebarItem Icon={FaDoorOpen} Text="Sair" />
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
