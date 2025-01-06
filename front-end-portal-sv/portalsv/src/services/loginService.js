import useEnv from "../hooks/useEnv";
import { toast } from "react-toastify";

export const loginService = {
  async login(loginData) {
    const { baseUrl, apiVersion } = useEnv();

    try {
      const response = await fetch(
        `${baseUrl}/auth?api-version=${apiVersion}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: localStorage.getItem("jwt")
              ? `Bearer ${localStorage.getItem("jwt")}`
              : "",
          },
          body: JSON.stringify(loginData),
        }
      );

      if (!response.ok) {
        const errorData = await response.json().catch(() => ({}));
        const errorMessage =
          errorData.message ||
          `Falha ao fazer login. Status: ${response.status}`;
        throw new Error(errorMessage);
      }

      const cookieToken = await response.text();
      console.log("cookieToken");
      console.log(cookieToken);
      toast.success("Login realizado com sucesso!");
      return cookieToken;
    } catch (error) {
      toast.error(error.message || "Erro ao realizar login. Tente novamente.");
      throw error;
    }
  },
};

export default loginService;
