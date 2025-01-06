import useEnv from "../hooks/useEnv";
import { toast } from "react-toastify";

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
      credentials: "include",
    });
    if (!response.ok) throw new Error("Falha ao deletar cliente");
  },

  async getClient(id) {
    const { baseUrl } = useEnv();
    const response = await fetch(`${baseUrl}/cliente/${id}`, {
      method: "GET",
      credentials: "include",
    });
    if (!response.ok) throw new Error("Falha ao pegar o cliente");
  },

  async createClient(clientData) {
    const { baseUrl } = useEnv();

    try {
      const response = await fetch(`${baseUrl}/cliente`, {
        method: "POST",
        credentials: "include",
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
      toast.error(error.message || "Erro na criação do cliente:");
      throw error;
    }
  },

  async updateClient(clientData) {
    const { baseUrl } = useEnv();
    try {
      const response = await fetch(`${baseUrl}/cliente`, {
        method: "PATCH",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...clientData,
          DataCriacao: new Date().toISOString(),
        }),
      });
    } catch (error) {
      toast.error(error.message || "Erro na criação do cliente:");
      throw error;
    }
  },
};
