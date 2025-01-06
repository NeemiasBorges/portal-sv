import { createContext, useContext, useState, useEffect } from "react";
import { loginService } from "../services/loginService";

const AuthContext = createContext(undefined);

export const AuthProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const checkAuthStatus = async () => {
    try {
      const response = await fetch("/api/check-auth", {
        credentials: "include",
      });
      const isAuthed = response.status === 200;
      setIsAuthenticated(isAuthed);
      return isAuthed;
    } catch (error) {
      console.error("Erro ao verificar autenticação:", error);
      setIsAuthenticated(false);
      return false;
    }
  };

  const login = async (loginData) => {
    try {
      const response = await loginService.login(loginData);
      if (response.ok) {
        setIsAuthenticated(true);
        return response;
      }
      return response;
    } catch (error) {
      setIsAuthenticated(false);
      throw error;
    }
  };

  const logout = async () => {
    try {
      const response = await loginService.logout();
      if (response.success) {
        setIsAuthenticated(false);
      }
      return response;
    } catch (error) {
      throw error;
    }
  };

  useEffect(() => {
    checkAuthStatus();
  }, []);

  if (!AuthContext) {
    throw new Error("AuthContext deve ser utilizado dentro de um AuthProvider");
  }

  const value = {
    isAuthenticated,
    login,
    logout,
    checkAuthStatus,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (context === undefined) {
    throw new Error("useAuth deve ser usado dentro de um AuthProvider");
  }
  return context;
};

export default AuthContext;
