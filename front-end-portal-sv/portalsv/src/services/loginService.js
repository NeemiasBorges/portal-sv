import useEnv from "../hooks/useEnv";

export const loginService = {
  async login(loginData) {
    const { baseUrl, apiVersion } = useEnv();

    try {
      const response = await fetch(`${baseUrl}/auth`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...loginData,
          "api-version": parseInt(apiVersion),
        }),
      });

      if (!response.ok) {
        throw new Error(`Falha ao fazer login. Status: ${response.status}`);
      }

      let token = response.json();
      console.log("AcessToken: ", token);
      return token;
    } catch (error) {
      console.error("Erro no login:", error.message);
      throw error;
    }
  },
};
