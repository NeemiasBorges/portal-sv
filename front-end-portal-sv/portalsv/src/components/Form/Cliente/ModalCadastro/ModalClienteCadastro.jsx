import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import Modal from "react-modal";
import { clienteService } from "../../../../services/clienteService";
import { PATTERNS } from "./constants";
import { modalStyles } from "./styles";
import FormField from "./FormField";

const ClienteCadastroModal = ({
  isOpen,
  onClose,
  onSuccess,
  isEditMode,
  client,
}) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm();

  useEffect(() => {
    if (isOpen && client && isEditMode) {
      reset({
        Nome: client.nome,
        Email: client.email,
        Telefone: client.telefone,
        Cep: client.cep,
        Cpf: client.cpf,
        Sexo: client.sexo,
      });
    }

    if (isOpen && client === null) {
      reset({
        Nome: "",
        Email: "",
        Telefone: "",
        Cep: "",
        Cpf: "",
        Sexo: "",
      });
    }
  }, [isOpen, client, reset]);

  const onSubmit = async (data) => {
    console.log("Verificacao dos dados", data);
    // Lógica para salvar os dados
    onSuccess();
  };

  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onClose}
      style={modalStyles}
      contentLabel="Cadastro de Cliente"
    >
      <form
        id="clientForm"
        onSubmit={handleSubmit(onSubmit)}
        className="space-y-4"
      >
        <h2 className="text-2xl font-bold mb-6">
          {isEditMode ? "Editar Cliente" : "Cadastro de Cliente"}
        </h2>

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
          label="Telefone"
          register={register}
          name="Telefone"
          validation={{
            required: "Telefone é obrigatório",
            pattern: { value: /^[0-9]{10,11}$/, message: "Telefone inválido" },
          }}
          errors={errors}
        />
        <FormField
          label="Cep"
          register={register}
          name="Cep"
          validation={{
            required: "CEP é obrigatório",
            pattern: { value: /^[0-9]{5}-?[0-9]{3}$/, message: "CEP inválido" },
          }}
          errors={errors}
        />
        <FormField
          label="Cpf"
          register={register}
          name="Cpf"
          validation={{
            required: "CPF é obrigatório",
            pattern: { value: /^[0-9]{11}$/, message: "CPF inválido" },
          }}
          errors={errors}
        />

        <label className="block text-sm font-medium text-gray-700">Sexo</label>
        <select
          {...register("Sexo", { required: "Sexo é obrigatório" })}
          className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
        >
          <option value="">Selecione...</option>
          <option value="M">Masculino</option>
          <option value="F">Feminino</option>
        </select>
        {errors.Sexo && (
          <span className="text-red-500 text-sm">{errors.Sexo.message}</span>
        )}

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
            className="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700"
          >
            {isEditMode ? "Salvar Alterações" : "Salvar"}
          </button>
        </div>
      </form>
    </Modal>
  );
};

export default ClienteCadastroModal;
