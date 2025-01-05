import { useState, useEffect } from "react";
import DataTable from "react-data-table-component";
import { FaUserPlus, FaUserTimes } from "react-icons/fa";
import { useClientManagement } from "../../hooks/useClienteManagements";
import ClienteCadastroModal from "../../components/Form/Cliente/ModalCadastro/ModalClienteCadastro";
import Header from "../../components/Header/HeaderComponent";
import TitleComponent from "../../components/TitleComponent";
import { columns } from "../../data/columnsData/clienteColumns";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import WithCustomProgressBar from "../../components/Animated/Toast/WithCustomProgressBar";

const ListClientePage = () => {
  const notify = (messageToast) => {
    toast(
      ({ closeToast, toastProps }) => (
        <WithCustomProgressBar
          closeToast={closeToast}
          toastProps={toastProps}
          data={{ message: messageToast }}
        />
      ),
      {
        autoClose: 3000,
      }
    );
  };

  const {
    clients,
    selectedRows,
    isLoading,
    handleDelete,
    handleEditClient,
    handleRowSelection,
    fetchClients,
    clearSelection,
    setClearSelection,
    resetForm,
  } = useClientManagement();

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedClient, setSelectedClient] = useState(null);

  const handleSuccess = () => {
    fetchClients();
    setIsModalOpen(false);
    if (selectedRows.length === 1) {
      handleEditClient();
      notify("Cliente editado com sucesso!");
    } else {
      notify("Cliente cadastrado com sucesso!");
    }
  };

  const handleEdit = () => {
    if (selectedRows.length === 1) {
      const client = clients.find((client) => client.id === selectedRows[0].id);
      client.Id = selectedRows[0].id;

      console.log("client", client);
      console.log(client);
      setSelectedClient(client);
      setIsModalOpen(true);
    }
  };

  const handleClearSelection = () => {
    setClearSelection(true);
  };

  const clearFormFields = () => {
    const fields = ["Nome", "Email", "Telefone", "Cep", "Cpf", "Sexo"];
    fields.forEach((fieldId) => {
      const element = document.getElementById(fieldId);
      if (element) {
        element.value = "";
      }
    });
  };

  useEffect(() => {
    if (!isModalOpen) {
      clearFormFields();
    }
  }, [isModalOpen]);

  const handleAddClient = () => {
    setIsModalOpen(true);
    if (selectedRows.length === 1) {
      handleClearSelection();
    }
    selectedRows.length = 0;
    resetForm();
    clearFormFields();

    setTimeout(() => {
      const fields = ["Nome", "Email", "Telefone", "Cep", "Cpf", "Sexo"];
      fields.forEach((fieldId) => {
        const element = document.getElementById(fieldId);
        if (element) {
          element.value = "";
          element.dispatchEvent(new Event("change", { bubbles: true }));
        }
      });
    }, 0);
  };

  return (
    <div>
      <Header />
      <TitleComponent>Listagem de Clientes</TitleComponent>

      <DataTable
        className="p-10 border-solid border-2 border-gray-300 mt-3"
        fixedHeader
        title="Clientes"
        pagination
        selectableRows
        columns={columns}
        data={clients}
        onSelectedRowsChange={handleRowSelection}
        clearSelectedRows={clearSelection}
      />

      <div className="flex justify-start items-center space-x-5 mt-5 ml-5">
        <button
          type="button"
          onClick={handleAddClient}
          className="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50 flex items-center space-x-2"
        >
          <span>Add Cliente</span>
          <FaUserPlus />
        </button>

        <button
          type="button"
          onClick={handleDelete}
          disabled={selectedRows.length !== 1 || isLoading}
          className={`px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 disabled:bg-blue-400 flex items-center space-x-2 ${
            isLoading || selectedRows.length !== 1 ? "cursor-not-allowed" : ""
          }`}
        >
          <span>Deletar Cliente</span>
          <FaUserTimes />
        </button>

        <button
          type="button"
          onClick={() => {
            handleEdit();
            handleEditClient();
          }}
          disabled={selectedRows.length !== 1 || isLoading}
          className={`px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-white bg-gray-800 hover:bg-gray-900 flex items-center space-x-2 ${
            isLoading || selectedRows.length !== 1 ? "cursor-not-allowed" : ""
          }`}
        >
          <span>Editar Cliente</span>
        </button>
      </div>

      <ClienteCadastroModal
        isOpen={isModalOpen}
        onClose={() => {
          setIsModalOpen(false);
          clearFormFields();
        }}
        onSuccess={handleSuccess}
        isEditMode={selectedRows.length === 1}
        client={selectedClient}
      />

      <ToastContainer />
    </div>
  );
};

export default ListClientePage;
