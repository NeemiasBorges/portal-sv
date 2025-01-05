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
    const response = await fetch(`${baseUrl}/cliente/delete/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) throw new Error("Falha ao deletar client");
  },
  async createClient(clientData) {
    const { baseUrl } = useEnv();
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
    if (!response.ok) throw new Error("Falha ao criar client");
    return response.json();
  },
};
