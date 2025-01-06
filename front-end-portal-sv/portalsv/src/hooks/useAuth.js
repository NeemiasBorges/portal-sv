import { useState, useEffect } from "react";
import { useNavigate } from "react-router";

export const useAuth = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem("jwt");
    setIsAuthenticated(!!token);
  }, []);

  const login = (token) => {
    localStorage.setItem("jwt", token);
    setIsAuthenticated(true);
    navigate("/clientes");
  };

  const logout = () => {
    localStorage.removeItem("jwt");
    setIsAuthenticated(false);
    navigate("/");
  };

  return { isAuthenticated, login, logout };
};

export default useAuth;
