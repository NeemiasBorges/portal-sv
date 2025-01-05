import { useState, useEffect, useCallback } from "react";
import { clienteService } from "../services/clienteService";

export const useClientManagement = () => {
  const [clients, setClients] = useState([]);
  const [selectedRows, setSelectedRows] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [clearSelection, setClearSelection] = useState(false);
  const [formData, setFormData] = useState({
    Nome: "",
    Email: "",
    Telefone: "",
    Cep: "",
    Cpf: "",
    Sexo: "",
  });

  const fillForm = useCallback((client) => {
    setFormData({
      Nome: client.nome,
      Email: client.email,
      Telefone: client.telefone,
      Cep: client.cep,
      Cpf: client.cpf,
      Sexo: client.sexo,
    });
  }, []);

  const resetForm = useCallback(() => {
    setFormData({
      Nome: "",
      Email: "",
      Telefone: "",
      Cep: "",
      Cpf: "",
      Sexo: "",
    });
  }, []);

  const fetchClients = useCallback(async () => {
    try {
      const data = await clienteService.getClients();
      setClients(data);
    } catch (error) {
      console.error("Error fetching clients:", error);
    }
  }, []);

  useEffect(() => {
    fetchClients();
  }, [fetchClients]);

  const handleDelete = async () => {
    if (selectedRows.length !== 1) return;

    setIsLoading(true);
    try {
      await clienteService.deleteClient(selectedRows[0].id);
      await fetchClients();
      setSelectedRows([]);
      setClearSelection(true);
      resetForm();
    } catch (error) {
      console.error("Error ao deletar o cliente:", error);
    } finally {
      setIsLoading(false);
    }
  };

  const handleEditClient = async () => {
    if (selectedRows.length !== 1) return;

    setIsLoading(true);
    try {
      const client = await clienteService.getClient(selectedRows[0].id);
      fillForm(client);
    } catch (error) {
      console.error("Error ao pegar o cliente especifico:", error);
    } finally {
      setIsLoading(false);
    }
  };

  const handleRowSelection = ({ selectedRows }) => {
    setSelectedRows(selectedRows);
    setClearSelection(false);
  };

  return {
    clients,
    selectedRows,
    isLoading,
    clearSelection,
    setClearSelection,
    handleDelete,
    handleEditClient,
    handleRowSelection,
    fetchClients,
    fillForm,
    resetForm,
    formData,
  };
};
