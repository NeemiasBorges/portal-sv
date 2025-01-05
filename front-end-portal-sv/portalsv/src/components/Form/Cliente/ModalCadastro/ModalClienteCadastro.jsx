import { useState } from "react";
import { useForm } from "react-hook-form";
import Modal from "react-modal";
import { clienteService } from "../../../../services/clienteService";
import { PATTERNS } from "./constants";
import { modalStyles } from "./styles";
import FormField from "./FormField";

const ClienteCadastroModal = ({ isOpen, onClose, onSuccess }) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm();
  const [isLoading, setIsLoading] = useState(false);

  console.log("Teste:", isOpen);

  const onSubmit = async (data) => {
    console.log("Verificacao dos daods" + data);
    setIsLoading(true);
    try {
      await clienteService.createClient(data);
      // reset();
      onSuccess();
    } catch (error) {
      console.error("Erro ao criar cliente:", error);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onClose}
      style={modalStyles}
      contentLabel="Cadastro de Cliente"
    >
      <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
        <h2 className="text-2xl font-bold mb-6">Cadastro de Cliente</h2>

        <div className="space-y-4">
          <FormField
            label="Nome"
            register={register}
            name="Nome"
            validation={{
              required: "Nome é obrigatório",
              minLength: { value: 3, message: "Mínimo 3 caracteres" },
              maxLength: { value: 100, message: "Máximo 100 caracteres" },
            }}
            errors={errors}
          />

          <FormField
            label="Email"
            type="email"
            register={register}
            name="Email"
            validation={{
              required: "Email é obrigatório",
              pattern: { value: /^\S+@\S+$/i, message: "Email inválido" },
            }}
            errors={errors}
          />

          <FormField
            label="CPF"
            register={register}
            name="Cpf"
            validation={{
              required: "CPF é obrigatório",
              pattern: {
                value: PATTERNS.CPF,
                message: "CPF deve ter 11 dígitos",
              },
            }}
            errors={errors}
          />

          <FormField
            label="Telefone"
            register={register}
            name="Telefone"
            validation={{
              pattern: {
                value: PATTERNS.PHONE,
                message: "Telefone inválido",
              },
            }}
            errors={errors}
          />

          <div>
            <label className="block text-sm font-medium text-gray-700">
              Sexo
            </label>
            <select
              {...register("Sexo", { required: "Sexo é obrigatório" })}
              className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
            >
              <option value="">Selecione...</option>
              <option value="M">Masculino</option>
              <option value="F">Feminino</option>
            </select>
            {errors.Sexo && (
              <span className="text-red-500 text-sm">
                {errors.Sexo.message}
              </span>
            )}
          </div>

          <FormField
            label="CEP"
            register={register}
            name="Cep"
            validation={{
              required: "CEP é obrigatório",
              pattern: {
                value: PATTERNS.CEP,
                message: "CEP deve ter 8 dígitos",
              },
            }}
            errors={errors}
          />
        </div>

        <div className="flex justify-end gap-4 mt-6">
          <button
            type="button"
            onClick={onClose}
            className="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50"
          >
            Cancelar
          </button>
          <button
            type="submit"
            disabled={isLoading}
            className="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 disabled:bg-blue-400"
          >
            {isLoading ? "Salvando..." : "Salvar"}
          </button>
        </div>
      </form>
    </Modal>
  );
};

export default ClienteCadastroModal;
