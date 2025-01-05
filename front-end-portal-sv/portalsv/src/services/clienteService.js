import useEnv from "../hooks/useEnv";

export const clienteService = {
  async getClients() {
    const { baseUrl, pageSize, firstPage } = useEnv();
    const response = await fetch(
      `${baseUrl}/cliente?numero_pagina=${firstPage}&quantidade_p_pagina=${pageSize}`
    );
    if (!response.ok) throw new Error("Falha ao pegar clients");
    return response.json();
  },

  async deleteClient(id) {
    const { baseUrl } = useEnv();
    const response = await fetch(`${baseUrl}/cliente/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) throw new Error("Falha ao deletar cliente");
  },

  async createClient(clientData) {
    const { baseUrl } = useEnv();

    try {
      const response = await fetch(`${baseUrl}/cliente`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...clientData,
          DataCriacao: new Date().toISOString(),
        }),
      });

      if (response.status !== 204) {
        throw new Error(`Falha ao criar cliente. Status: ${response.status}`);
      }
    } catch (error) {
      console.error("Erro na criação do cliente:", error.message);
      throw error;
    }
  },
};
