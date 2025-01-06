import PropTypes from "prop-types";
import { FaKey, FaTimes, FaUser, FaRobot, FaDoorOpen } from "react-icons/fa";
import SidebarItem from "../SidebarItem/SidebarItemComponent";
import { Container, Content } from "./styles";
import { Link } from "react-router";
import useAuth from "../../hooks/useAuth";

const Sidebar = ({ active, closeSidebar }) => {
  const { isAuthenticated, logout } = useAuth();

  return (
    <Container sidebar={active}>
      <FaTimes className="size-4" onClick={closeSidebar} />
      <Content>
        <Link to="/chatbot">
          <SidebarItem Icon={FaRobot} Text="Chatbot" />
        </Link>

        <Link to="/clientes">
          <SidebarItem Icon={FaUser} Text="Clientes" />
        </Link>

        {!isAuthenticated ? (
          <Link to="/">
            <SidebarItem Icon={FaKey} Text="Login" />
          </Link>
        ) : (
          <div onClick={logout} style={{ cursor: "pointer" }}>
            <SidebarItem Icon={FaDoorOpen} Text="Sair" />
          </div>
        )}
      </Content>
    </Container>
  );
};

Sidebar.propTypes = {
  active: PropTypes.bool.isRequired,
  closeSidebar: PropTypes.func.isRequired,
};

export default Sidebar;
