import { useState, useEffect, useCallback } from "react";
import { clienteService } from "../services/clienteService";

export const useClientManagement = () => {
  const [clients, setClients] = useState([]);
  const [selectedRows, setSelectedRows] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

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
      console.log(selectedRows);
      console.log("selectedRows[0].Id", selectedRows[0].id);
      await clienteService.deleteClient(selectedRows[0].id);
      await fetchClients();
      setSelectedRows([]);
    } catch (error) {
      console.error("Error deleting client:", error);
    } finally {
      setIsLoading(false);
    }
  };

  const handleRowSelection = ({ selectedRows }) => {
    setSelectedRows(selectedRows);
  };

  return {
    clients,
    selectedRows,
    isLoading,
    handleDelete,
    handleRowSelection,
    fetchClients,
  };
};
