import { useState } from "react";
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
import resetForm from "../../components/Form/Cliente/ModalCadastro/ModalClienteCadastro";
const ListClientePage = () => {
  const notify = () => {
    toast(
      ({ closeToast, toastProps }) => (
        <WithCustomProgressBar
          closeToast={closeToast}
          toastProps={toastProps}
          data={{ message: "Cliente Cadastrado com sucesso" }}
        />
      ),
      {
        autoClose: 3000, // Tempo de exibição do Toast
      }
    );
  };

  // Hooks do gerenciamento de clientes
  const {
    clients,
    selectedRows,
    isLoading,
    handleDelete,
    handleEditClient,
    handleRowSelection,
    fetchClients,
    clearSelection,
    setClearSelection, // Importado do hook
  } = useClientManagement();

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedClient, setSelectedClient] = useState(null); // Armazenar o cliente selecionado

  const handleSuccess = () => {
    fetchClients();
    setIsModalOpen(false);
    notify();
  };

  const handleEdit = () => {
    if (selectedRows.length === 1) {
      // Obtém o cliente selecionado
      const client = clients.find((client) => client.id === selectedRows[0].id);
      setSelectedClient(client); // Armazena o cliente selecionado
      setIsModalOpen(true);
    }
  };

  // Limpa a seleção manualmente
  const handleClearSelection = () => {
    setClearSelection(true);
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
          onClick={() => {
            setIsModalOpen(true);
            selectedRows.length === 1 && handleClearSelection();
            selectedRows.length = 0;
            resetForm();
          }}
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
          onClick={handleEdit} // Abre o modal em modo de edição
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
        onClose={() => setIsModalOpen(false)}
        onSuccess={handleSuccess}
        isEditMode={selectedRows.length === 1}
        client={selectedClient} // Passando o cliente para o modal
      />

      <ToastContainer />
    </div>
  );
};

export default ListClientePage;
